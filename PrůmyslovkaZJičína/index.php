

<!doctype html>

<html>
	<head>
		<meta charset="utf-8">
		<meta name="theme-color" content="red">
		<meta name="viewport" content="width=device-width,initial-scale=1">
		<title>Kalendář</title>
		<link href="style.css" rel="stylesheet">
		<link href="icon.png" rel="shortcut icon">
		<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
	</head>

	<body>
		<header>
			<h1>Akce Královéhradeckého Kraje</h1>
			<div id="selectLanguage">
				<form method="get" if="lang_form">
				<select id="language" name="language">
					<option value="cs">Cs</option>
					<option value="en">En</option>
					<option value="pl">Pl</option>
					<option value="ru">Ru</option>
					<option value="de">De</option>
					<option value="nl">Nl</option>
					<option value="fr">Fr</option>
					<option value="it">It</option>
					<option value="sp">Sp</option>
				</select>
				</form>
			</div>
		</header>

		<main>
			<?php
				$lang = "en";
				require "sFunkci.php";
				
				for($i = 0; $i <300; $i++) {
					$event = $events[$i];
					echo($event->name["cs"]."<br>");
					echo("<a href='http://".$event->url."'>".$event->url."</a><p>");
				}
			?>
		</main>

		<footer>
			<?php echo("last update: ".date("d. m. Y", filemtime("index.php"))); ?>
		</footer>
		<script src="script.js" type="text/javascript"></script>
		<textarea style="display: none;">
	</body>
</html>