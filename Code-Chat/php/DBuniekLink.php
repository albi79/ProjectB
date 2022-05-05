<?php
require 'config.php';
$value = $_POST['value'];
$idLink = $_POST['idLink'];

$allRows = "SELECT link FROM uniekLink";
$result = $mysqli->query($allRows);
while ($row = mysqli_fetch_array($result)) {
    if ($row['link'] == $idLink) {
        $idLink = substr(str_shuffle("0123456789abcdefghijklmnopqrstvwxyz"), 0, 9);
    }
}
// $uniekUrl = trim(substr("$_SERVER[REQUEST_URI]", strrpos("$_SERVER[REQUEST_URI]", '?') + 1));
$sql = "INSERT INTO uniekLink (link, content) VALUES ('$idLink', '$value')";
$mysqli->query($sql);
$mysqli->close();
echo $idLink;
