<?php
    session_start();

?>

<!-- Is its own document so it can be referenced in other documents for simplicitys  -->
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width= , initial-scale=1.0">
    <link rel="stylesheet" href="css/style.css">
    <link rel="stylesheet" href="css/reset.css">
    <title>PHP project</title>
</head>
<body>
    
    <nav>
        <div class="wrapper">
            <ul>
                <li><a href="index.php">Home Page</a></li>
                <li><a href="laws.php">Laws</a></li>
                <?php
                if (isset($_SESSION["useruid"])) {
                    echo "<li><a href='game.php'>The Game</a></li>";
                    echo "<li><a href='includes/logout.inc.php'>Log out</a></li>";
                }
                else {
                    echo "<li><a href='signup.php'>Sign up</a></li>";
                    echo "<li><a href='login.php'>Log In</a></li>";
                }
                ?>
            </ul>
        </div>
    </nav>    
    
    <div class="wrapper">