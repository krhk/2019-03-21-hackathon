<?= $nav ?>

<!-- mainpage - searchpage -->
<div class="main">
    <div class="bg-layer"></div> <!-- BG black layer -->
    <div class="container main-page">
        <div class="row">
            <div class="col-12 header-content">
                <h1>Najděte si svého doktora v Královehradeckém kraji.</h1>

                <form class="search-bar bg-light" method="POST" action="">
                    <input type="text" name="q" placeholder="Např.: Rychnov nad Kněžnou">
                    <button type="submit" class="search-bar-btn">Vyhledat</button>
                </form>
            </div>
        </div>
    </div>

    <div class="search-down-icon">
        <a href="#">Podrobnější vyhledávání</a>
        <img src="public/views/themes/default/assets/angle-down.png" alt="">
    </div>
</div>
<!-- end of mainpage -->

<!-- Filter -->
<div class="container">
    <div class="row">
        <form class="filter-page">
            <h1>Podrobnější filtrované vyhledávání</h1>
            <p>Specifikujte informace o lékaři.</p>

            <div class="filter-bar">
                <div class="data" data-child="typ-kliniky">
                    Typ kliniky
                </div>
                <div class="data" data-child="pro-koho">
                    Pro koho
                </div>
                <div class="data" data-child="okres">
                    Okres
                </div>
                <div class="data" data-child="obec">
                    Obec
                </div>

                <button type="submit" class="filter-btn">Aktivovat filtr</button>
            </div>
            <div class="filter-sub-bar typ-kliniky">
                <div class="data">
                    Lékařská pohotovost
                    <input type="radio" value="lékařská pohotovost" name="type" id="">
                </div>
                <div class="data">
                    Stomatologická pohotovost
                    <input type="radio" value="stomatologická pohotovost" name="type" id="">
                </div>
            </div>
            <div class="filter-sub-bar pro-koho">
                <div class="data">
                    Děti
                    <input type="radio" value="děti" name="who" id="">
                </div>
                <div class="data">
                    Dospělí
                    <input type="radio" value="dospělí" name="who" id="">
                </div>
                <div class="data">
                    Všichni
                    <input type="radio" value="všichni" name="who" id="">
                </div> 
            </div>
            <div class="filter-sub-bar okres">
                <?php foreach($okresy as $okres): ?>
                    <div class="data">
                        <?= $okres ?>
                        <input type="radio" value="<?= $okres ?>" name="okres_name" id="">
                    </div>
                <?php endforeach; ?>
            </div>
            <div class="filter-sub-bar obec">
                <?php foreach($obce as $obec): ?>
                    <div class="data">
                        <?= $obec ?>
                        <input type="radio" value="<?= $obec ?>" name="obec_name" id="">
                    </div>
                <?php endforeach; ?>
            </div>
        </form>
    </div>
</div>
<!-- End of filter -->

<!-- results -->
<div class="container results-container">
    <div class="row">
        <div class="results">
            <div class="col-12">
                <button class="return-back-btn">Vrátit zpět</button>
                <h1>Výsledky filtrování</h1>
                <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Corporis, sint itaque. Magni expedita cupiditate, voluptate, voluptates ipsa blanditiis pariatur quidem architecto aut molestias totam animi officiis ratione possimus obcaecati. Nostrum.</p>

                <table class="nice-table">
                    <tr>
                        <th>Typ</th>
                        <th>Věk</th>
                        <th>Telefon</th>
                        <th>kód okresu</th>
                        <th>Okres</th>
                        <th>Kód obce</th>
                        <th>Název obce</th>
                        <th>Název pohotovosti</th>
                        <th>Ulice</th>
                        <th>ČP</th>
                        <th>Ordninační hodiny</th>
                    </tr>
                    <tr>
                        <td>1</td>
                        <td>John</td>
                        <td>Doe</td>
                        <td>1</td>
                        <td>John</td>
                        <td>Doe</td>
                        <td>1</td>
                        <td>John</td>
                        <td>Doe</td>
                        <td>1</td>
                        <td>John</td>
                    </tr>
                    <tr>
                        <td>1</td>
                        <td>John</td>
                        <td>Doe</td>
                        <td>1</td>
                        <td>John</td>
                        <td>Doe</td>
                        <td>1</td>
                        <td>John</td>
                        <td>Doe</td>
                        <td>1</td>
                        <td>John</td>
                    </tr>
                    <tr>
                        <td>1</td>
                        <td>John</td>
                        <td>Doe</td>
                        <td>1</td>
                        <td>John</td>
                        <td>Doe</td>
                        <td>1</td>
                        <td>John</td>
                        <td>Doe</td>
                        <td>1</td>
                        <td>John</td>
                    </tr>

                </table>
            </div>
        </div>

    </div>
</div>
<!-- end of results -->

<?= $footer ?>