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

// Lekérdezés az ölés számokról
$sql = "SELECT p1_kills, p2_kills FROM kills";
$result = $conn->query($sql);

if ($result->num_rows > 0) {
  // Kilépés az asszociatív tömb formátumú eredményből
  $row = $result->fetch_assoc();
  echo json_encode($row);
} else {
  echo "0 results";
}

$conn->close();
?>