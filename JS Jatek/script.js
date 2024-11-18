const canvas = document.querySelector('canvas');
const context = canvas.getContext('2d');
canvas.width = 1024;
canvas.height = 576;
context.fillRect(0, 0, canvas.width, canvas.height);

document.addEventListener('DOMContentLoaded', function() {
  const menu = document.getElementById('menu');
  const playButton = document.getElementById('playButton');
  canvas.style.display = 'none';
  const blokk = document.getElementById('blokk');
  blokk.style.display = 'none';
  playButton.addEventListener('click', function() {
    startGame();
    blokk.style.display = 'inline-block';
  });

  controlsButton.addEventListener('click', function() {
    showControls();
  });

  function startGame() {
    menu.style.display = 'none';
    canvas.style.display = 'block';
    //getKillCountsFromServer();
    animate();
  }

  function showControls() {
    alert('Controls:\nPlayer 1: WASD mozgás, X lövés\nPlayer 2: Nyilak mozgás, Space lövés');
  }

  function endGame() {
    canvas.style.display = 'none';
    menu.style.display = 'block';
  }
});

const playerHeight = canvas.height - 100;

const player1 = new Playah({
    position: {
      x: 50,
      y: 0  
    },
    velocity: {
      x: 0,
      y: 0
    },
    image:'stickman2.png',
    health: 100
}
)
player1.draw();

const player2 = new Playah({
  position: {
    x: 900,
    y: 100
  },
  velocity: {
    x: 0,
    y: 0
  },
  image:'stickman.png',
  health: 100
})
player2.draw();

const bullets = [];

const keys = {
  a: {
    pressed: false
  },
  d: {
    pressed: false
  },
  ArrowRight: {
    pressed: false
  },
  ArrowLeft: {
    pressed: false
  },
  w: {
    pressed: false
  },
  ArrowUp: {
    pressed: false
  },
  x: {
    pressed: false
  },
  Space: {
    pressed: false
  }
}
let lastKey;

const backgroundImage = new Image();
backgroundImage.src = 'bg.gif';

let p1_killCount = 0;
let p2_killCount = 0;

function animate() {
    window.requestAnimationFrame(animate);
    context.drawImage(backgroundImage, 0, 0, canvas.width, canvas.height);
    player1.update();
    player2.update();
    player1.velocity.x = 0;
    player2.velocity.x = 0;

    //player1
    if(keys.a.pressed && player1.lastKey === 'a') {
      player1.velocity.x = -2.5;
    } else if (keys.d.pressed && player1.lastKey === 'd') {
      player1.velocity.x = 2.5;
    }

    //player2
    if (keys.ArrowRight.pressed && player2.lastKey === 'ArrowRight') {
      player2.velocity.x = 2.5;
    } else if (keys.ArrowLeft.pressed && player2.lastKey === 'ArrowLeft') {
      player2.velocity.x = -2.5;
    }


    if (keys.x.pressed && !player1.shooting) {
      const bulletVelocityX = player1.lastKey === 'd' ? 5 : -5;
      bullets.push(new Bullet({
        position: { x: player1.position.x + (player1.lastKey === 'd' ? 30 : -10), y: player1.position.y + player1.height / 2 - 2.5 },
        velocity: { x: bulletVelocityX, y: 0 },
        shooter: player1
      }));
      player1.shooting = true;
    }
    

    if (keys.Space.pressed && !player2.shooting) {
      const bulletVelocityX = player2.lastKey === 'ArrowRight' ? 5 : -5;
      bullets.push(new Bullet({
        position: { x: player2.position.x + (player2.lastKey === 'ArrowRight' ? 30 : -10), y: player2.position.y + player2.height / 2 - 2.5 },
        velocity: { x: bulletVelocityX, y: 0 },
        shooter: player2
      }));
      player2.shooting = true;
    }

    bullets.forEach(bullet => {
      bullet.update();
  
      if (bullet.position.x >= player2.position.x && bullet.position.x <= player2.position.x + 30 &&
        bullet.position.y >= player2.position.y && bullet.position.y <= player2.position.y + player2.height) {
        player2.health -= 10;
        bullets.splice(bullets.indexOf(bullet), 1);
  
        if (player2.health <= 0) {
          alert("Player 1 wins!"); // Player1 nyert
          p1_killCount += 1;
          saveKillCountsToServer(p1_killCount, p2_killCount);
          resetGame();
        }
      } else if (bullet.position.x <= player1.position.x + 30 && bullet.position.x >= player1.position.x &&
        bullet.position.y >= player1.position.y && bullet.position.y <= player1.position.y + player1.height) {
        player1.health -= 10;
        bullets.splice(bullets.indexOf(bullet), 1);
  
        if (player1.health <= 0) {
          alert("Player 2 wins!"); // Player 2 győzött
          p2_killCount += 1;
          saveKillCountsToServer(p1_killCount, p2_killCount);
          resetGame();
        }
      }
    });
    document.getElementById("player1Health").innerText = `P1 HP: ${player1.health}`;
  document.getElementById("player2Health").innerText = `P2 HP: ${player2.health}`;
  document.getElementById("kills").innerText = `${p1_killCount} | ${p2_killCount}`;

}
function resetGame() {

  bullets.length = 0;
  player1.health = 100;
  player2.health = 100;
  player1.position.x = 0;
  player1.position.y = 0;
  saveKillCountsToServer(p1_killCount, p2_killCount);
  getKillCountsFromServer();
  updateKillDisplay();
}

function getKillCountsFromServer(callback) {
  var xhr = new XMLHttpRequest();
  xhr.open("GET", "../PHP/get_kills.php", true);
  xhr.onreadystatechange = function() {
    if (xhr.readyState == 4 && xhr.status == 200) {
      var response = JSON.parse(xhr.responseText);
      callback(response);
    }
  };
  xhr.send();
}

function saveKillCountsToServer(p1_killCount, p2_killCount) {
  var xhr = new XMLHttpRequest();
  xhr.open("POST", "../PHP/save_kills.php", true);
  xhr.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
  xhr.onreadystatechange = function() {
    if (xhr.readyState == 4 && xhr.status == 200) {
      console.log(xhr.responseText);
    }
  };
  var params = "p1_killCount=" + p1_killCount + "&p2_killCount=" + p2_killCount;
  xhr.send(params);
}

function updateKillDisplay() {
  document.getElementById("kills").innerText = `${p1_killCount} | ${p2_killCount}`;
}

animate();

window.addEventListener('keydown', (event) => {
  keys[event.key] && (keys[event.key].pressed = true);

  switch(event.key) {
    case 'd':
      keys.d.pressed = true;
      player1.lastKey = 'd';
      break;
    case 'a':
      keys.a.pressed = true;
      player1.lastKey = 'a';
      break;
    case 'ArrowRight':
      keys.ArrowRight.pressed = true;
      player2.lastKey = 'ArrowRight';
      break;
    case 'ArrowLeft':
      keys.ArrowLeft.pressed = true;
      player2.lastKey = 'ArrowLeft';
      break;
    case 'w':
      if (!player1.jumping) {
        player1.jump();
      }
      break;
    case 'ArrowUp':
      if (!player2.jumping) {
        player2.jump();
      }
      break;
    case 'x':
      keys.x.pressed = true;
      break;
    case ' ':
      keys.Space.pressed = true;
      break;
  }
})

window.addEventListener('keyup', (event) => {
  keys[event.key] && (keys[event.key].pressed = false);
  switch(event.key) {
    case 'd':
      keys.d.pressed = false;
      break;
    case 'a':
      keys.a.pressed = false;
      break;
    case 'ArrowRight':
      keys.ArrowRight.pressed = false;
      break;
    case 'ArrowLeft':
      keys.ArrowLeft.pressed = false;
      break;
    case 'x':
        player1.shooting = false;
        break;
    case ' ':
        player2.shooting = false;
        break;
}})