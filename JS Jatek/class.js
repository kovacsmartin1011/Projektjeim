class Sprite {
    constructor({position, imageSrc}) {
        this.position = position;
        this.width = 50;
        this.height = 150;
        this.image = new Image();
        this.imageSrc = this.imageSrc;
    }
    draw() 
    {
        context.drawImage(this.image, this.position.x, this.position.y);
    }

    update()
    {
        this.draw();
    }
}

class Playah {
    constructor({position, velocity, image, health}) {
      this.position = position;
      this.velocity = velocity;
      this.height = 65;
      this.lastKey;
      this.health = 100;
      this.gravity = 0.05;
      this.jumping = false;
      this.startY = position.y;
      this.image = new Image();
      this.image.src = image;
    };
  
    draw() {
      context.drawImage(this.image, this.position.x, this.position.y, 30, this.height);
    }
  
    update() {
      this.draw();
      this.applyGravity();
      this.checkHorizontalColls();
      const newX = this.position.x + this.velocity.x;
      const newY = this.position.y + this.velocity.y;
  
      if (newX >= 0 && newX + 30 <= canvas.width) {
          this.position.x = newX;
      }
  
      if (newY >= 0 && newY + this.height <= canvas.height / 1.65) {
          this.position.y = newY;
      }
  
      if(this.position.y + this.height + this.velocity.y >= canvas.height/1.65) {
        this.velocity.y = 0;
      }
      else
      {
        this.velocity.y += this.gravity;
      }
  
      if (this.position.y >= this.startY) {
        this.jumping = false;
      }
    }
  
    jump()
    {
      if (!this.jumping && this.velocity.y === 0)  {
        this.velocity.y = -5;
        this.jumping = true;
      }
    }

    applyGravity()
    {
        this.velocity.y += this.gravity;
        this.position.y += this.velocity.y;
    }

    checkHorizontalColls()
    {
        if(this.position.y + this.height >= canvas.height / 1.65)
        {
            this.velocity.y = 0;
            this.position.y = canvas.height / 1.65 - this.height;
        }
    }
}
class Bullet {
    constructor({position, velocity, color = '#FF8C8C'}) {
      this.position = position;
      this.velocity = velocity;
      this.width = 10;
      this.height = 5;
      this.color = color;
    }
  
    draw() {
      context.fillStyle = this.color;
      context.fillRect(this.position.x, this.position.y, this.width, this.height);
    }
  
    update() {
      this.draw();
  
      this.position.x += this.velocity.x;
      this.position.y += this.velocity.y;
      
    }
  }