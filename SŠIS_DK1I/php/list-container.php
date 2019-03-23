<?php
	while($row = mysqli_fetch_array($result, MYSQLI_ASSOC)) {
		$id = "{$row['id']}";
		$name = "{$row['Jmeno_lekare']}";
		$adress = "{$row['Ulice']} {$row['Cislo_popisne']}, {$row['Nazev_obce']}";
		print_r ("
			<div class='list-item' onclick='writeFromList($id)'>
				<h4 class='listI-name'> $name </h4>
				<p class='listI-adress'> $adress </p>
			</div>
		");
	}
?>
