<!DOCTYPE html>
<html>
    <head>
        <link rel="icon" href="images/icon.ico" type="image/ico" sizes="16x16">
        <meta http-equiv="Pragma" content="no-cache">
        <link href="https://fonts.googleapis.com/css?family=Open+Sans" rel="stylesheet">
        <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.7.2/css/all.css" integrity="sha384-fnmOCqbTlWIlj8LyTjo7mOUStjsKC4pOpQbqyi7RrhN7udi9RwhKkMHpvLbHG9Sr" crossorigin="anonymous">
        <script type="text/javascript" src="https://api.mapy.cz/loader.js"></script>
        <script type="text/javascript">Loader.load()</script>
        <meta charset="UTF-8">
        <link rel="stylesheet" href="style/main.css">

        <title>bolimnezub.cz</title>
        <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no">
        <script type="text/javascript" src="js/draw_map.js"></script>
        <script src="js/map_list.js"></script>
        <script type="text/javascript" src="js/listWritter.js"></script>
    </head>
    <body onload="mapColor()" onresize="timer()">
        <header>
            <div class="top-bar">
              <a href="#"><h1>BOLIMNEZUB.CZ</h1></a>
            </div>
        </header>
        <section>
            <div id="section-wrapper">
                <div class="main-box">
                    <div class="content-container">
                        <article id="search">
                            <div class="search-wrapper">
                                <form action="">
                                    <input class="searchInput fa" type="text" placeholder="Vyhledejte svého zubaře..." style="font-family:Arial, FontAwesome" />
                                </form>
                            </div>
                        </article>
                        <article id="map" class="leftpanel">
                            <div class="switch-bar">
                                <a class="button" id="mapBtnI" href="#" onclick="mlSwitch('list','map')"><i class="fas fa-map-marker-alt"></i>MAPA</a>
                                <a class="button" id="listBtnI" href="#" onclick="mlSwitch('map','list')"><i class="fas fa-list"></i>SEZNAM</a>
                                <div style="clear:both"></div>
                            </div>
                            <div class="article-wrapper">
                                <div id="SMap">
                                      <script type="text/javascript">
                                          draw_map();
                                      </script>
                                </div>
                            </div>
                        </article>
                        <article id="list" class="leftpanel">
                                <div class="switch-bar">
                                        <a class="button" id="mapBtnII" href="#" onclick="mlSwitch('list','map')"><i class="fas fa-map-marker-alt"></i>MAPA</a>
                                        <a class="button" id="listBtnII" href="#" onclick="mlSwitch('map','list')"><i class="fas fa-list"></i>SEZNAM</a>
                                    <div style="clear:both"></div>
                                </div>
                                <div class="article-wrapper">
                                    <div class="list-container">
                                          <?php require('php/mysqli_query.php'); ?>
                                          <?php require('php/list-container.php'); ?>
                                    </div>
                                </div>
                            </article>
                        <article  id="info-panel">
                            <div class="article-wrapper">
                                <?php require('php/info-panel.php'); ?>
                            </div>
                        </article>
                    </div>
                </div>
            </div>
        </section>
        <footer>Vytvořili <br> Suchánek & Batelka & Houžvička & Guzan</footer>
    </body>
</html>
