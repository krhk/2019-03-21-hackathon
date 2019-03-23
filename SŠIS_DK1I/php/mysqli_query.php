<?php
	$link = mysqli_connect("localhost:3306", "W3b0vky", "H3sL0mAr1@DBpHp9259@!!@?", "soutez");
	$sql = 'SELECT * FROM data';

	mysqli_set_charset($link,"utf8");

	$result = mysqli_query( $link, $sql );
	mysqli_close($link);

	$address = mysqli_query("SELECT * FROM data WHERE id='1'");
	$address = "Nádražní 45";
?>
