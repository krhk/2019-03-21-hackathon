<?php
	$link = mysqli_connect("localhost:3306", "W3b0vky", "H3sL0mAr1@DBpHp9259@!!@?", "soutez");
	$sql = 'SELECT * FROM users_admin';

	mysqli_set_charset($link,"utf8");

	//$result = mysqli_query($link);
	mysqli_close($link);
?>