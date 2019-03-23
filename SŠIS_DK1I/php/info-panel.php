<?php
	$jmeno = $row['Jmeno_lekare'];
	$ulice = $row['Ulice'];
	$cp = $row['Cislo_popisne'];
	$obec = $row['Nazev_obce'];
	$telefon = $row['Telefon'];

	/*print_r ("
		<div class='basic-info'>
			<h1 class='doctor-name'>$jmeno</h1>
			<div class='adress'>
				<p class='street'>$ulice</p>
				<p class='number'>$cp</p>
			</div>
			<div class='city'>
				<p class='city-name'>$obec</p
			</div>
		</div>
		<div class='contact'>
			<h4 class='contact-header'>KONTAKT</h4>
			<p><i class='fas fa-mobile-alt'></i> Tel. $telefon</p>
			<p> Otevírací doba: $oteviracidoba</p>
		</div>
");*/

print_r ("
		<div class='basic-info'>
			<h1 id='doctor-name'>MDDr. Filip Král s.r.o</h1>
			<div class='adress'>
				<h4 class='adress-header'>ADRESA</h4>
				<p id='street'>Ulice: Kukulova</p>
				<p id='number'>442</p>
				<div style='clear:both'></div>
				<p id='city-name'>Město: Jičín</p>
			</div>
		</div>
		<div class='contact'>
			<h4 class='contact-header'>KONTAKT</h4>
			<span><i class='fas fa-mobile-alt'></i></span>
			<span id='phone'>Tel. +420 724 236 008</span>
			<p id='opening'>Otevírací doba: SO,NE, svátky: 8:00 - 12:00</p>
		</div>
	");
?>
