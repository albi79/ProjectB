<?php
$db_host = 'localhost';
$db_user = 'root';
$db_password = 'root';
$db_db = 'code-chat';

$mysqli = @new mysqli(
    $db_host,
    $db_user,
    $db_password,
    $db_db
);

if ($mysqli->connect_error) {
    echo 'Errno: ' . $mysqli->connect_errno;
    echo '<br>';
    echo 'Error: ' . $mysqli->connect_error;
    exit();
}


// $sql = "SELECT id, link FROM uniekLink";
// $result = $mysqli->query($sql);

// if ($result->num_rows > 0) {
//     // output data of each row
//     while ($row = $result->fetch_assoc()) {
//         echo "id: " . $row["id"] . " - link: " . $row["link"] . "<br>";
//     }
// } else {
//     echo "0 results";
// }

// $mysqli->close();
