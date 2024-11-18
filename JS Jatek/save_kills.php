<?php
$servername = "mysql.caesar.elte.hu";
$username = "ubwrvy";
$password = "39mh4DnXxWbGrGSH";
$dbname = "ubwrvy";

$conn = new mysqli($servername, $username, $password, $dbname);

// Ellenőrizze a kapcsolatot
if ($conn->connect_error) {
  die("Kapcsolódási hiba: " . $conn->connect_error);
}

// POST adatok fogadása és az ölés számok frissítése
if ($_SERVER["REQUEST_METHOD"] == "POST") {
  $p1_killCount = $_POST["p1_killCount"];
  $p2_killCount = $_POST["p2_killCount"];

  $sql = "UPDATE kills SET P1=$p1_killCount, P2=$p2_killCount";

  if ($conn->query($sql) === TRUE) {
    echo "Az ölés számok sikeresen frissültek.";
  } else {
    echo "Hiba az ölés számok frissítése közben: " . $conn->error;
  }
}

$conn->close();
?>