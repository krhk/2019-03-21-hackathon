<!DOCTYPE HTML>
<html>
    <head>
        <base href="/">
        
        <meta http-equiv="content-type" content="text/html; charset=utf-8">
        <meta name="viewport" content="width=device-width,initial-scale=1">
        
        <link href='layout/main.css' rel='stylesheet'>
        <link href='layout/map/style.css' rel='stylesheet'>
        <link href='layout/animate.css' rel='stylesheet'>
        <link href="https://fonts.googleapis.com/css?family=Baloo" rel="stylesheet">
        <link href="https://fonts.googleapis.com/css?family=Raleway:100,300,400,700,900" rel="stylesheet">

        <script src="https://unpkg.com/popper.js@1/dist/umd/popper.min.js"></script>
        <script src="https://unpkg.com/tippy.js@4"></script>
        
        <link rel="stylesheet" href="https://unpkg.com/leaflet@1.4.0/dist/leaflet.css" integrity="sha512-puBpdR0798OZvTTbP4A8Ix/l+A4dHDD0DGqYW6RQ+9jxkRFclaxxQb/SJAWZfWAkuyeQUytO7+7N4QKrDh+drA==" crossorigin=""/>
    <script src="https://unpkg.com/leaflet@1.4.0/dist/leaflet.js" integrity="sha512-QVftwZFqvtRNi0ZyCtsznlKSWOStnDORoefr1enyq5mVL4tmKB3S/EnC3rRJcxCPavG10IcrVGSmPh6Qw5lwrg==" crossorigin=""></script>
        
        <title><?= $settings['MainTitle']; ?> | <?= $connection->pageTitle; ?></title>
    </head>
    <body>
        
        <?php               
            date_default_timezone_set('Europe/Prague');
        ?>
        <div class="frame">
            <div class="box">
                <?php
                    include $connection->file;
                ?>
            </div>
            <div class="box sidemenu">
                <div class="main-title"><a href="home"><?= $settings["MainTitle"]; ?></a></div>
                <div class="data-set-menu">
                    <?php if($connection->parsedUrl[0]=="map1") {$ac = 'active';}else{$ac = "";} ?>
                    <a href="map1"><div class="item <?= $ac ?>">Počet nemovitostí</div></a>

                    <?php if($connection->parsedUrl[0]=="map2") {$ac = 'active';}else{$ac = "";} ?>
                    <a href="map2"><div class="item <?= $ac ?> tip" data-tippy-content="Plánováno do budoucnosti">Nezaměstnanost vs. nemovitosti</div></a>
                    
                    <div class="back"><a href="home">Vrátit se na úvodní stránku</a></div>
                </div>

                <?php 
                    if($connection->parsedUrl[0]=="map1"){
                        echo "<h3>Legenda mapy</h3>";
                    }
                ?>
                
                <table class="legend">
                    <tr class="item"><td class="color" style="background-color: #00bcd48f;"></td><td class="text">
                        
                        <?php 
                            if($connection->parsedUrl[0]=="map1") echo "žádná nalezená nemovitost";
                            if($connection->parsedUrl[0]=="map2") echo "žádná nalezená nemovitost";
                            if($connection->parsedUrl[0]=="map3") echo "pro tuto oblast v tuto chvíli nemáme data";
                        ?>
                    </td></tr>
                </table>

                <?php 


                    if($connection->parsedUrl[0]=="map2"){
                        echo "<h3>Barevný index</h3>
                            <p>Jedná se o barvu která ukazuje poměr mezi nezaměstnanotí a nemovitostí v prodeji.</p>";
                    }
                ?>

                <div class="alert">
                    Data v tuto chvíli nejsou dostupná. Zkuste to později.
                </div>

                <div class="autors">
                    Vytvořiů team <span class="team">DeltaSquat</span> -  
                    <a href="#linkdin" target="_blank">Vítek Falta</a>, 
                    <a href="#linkdin" target="_blank">Matěj Půhoný</a>
                </div>
            </div>
        </div>
        <script>
            tippy('.tip')
        </script>
    </body>
</html>
