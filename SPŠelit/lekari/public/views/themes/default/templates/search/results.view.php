<!-- results -->
<div class="results">
    <div class="col-12">
        <button class="return-back-btn">Vrátit zpět</button>
        <h1>Výsledky filtrování</h1>
        <p>Tyto výsledky byly vygenerovány na základě vašeho vyhledávání</p>

        <table class="nice-table">
            <?php if(empty($search_results[0])): ?>
            
                <tr>
                    <h1>Žádné výsledky</h1>
                </tr>

            <?php else: ?>

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

                <?php foreach($search_results as $result): ?>
                    <tr>
                        <td><?= $result['type'] ?></td>
                        <td><?= $result['who'] ?></td>
                        <td><?= $result['doc_phone'] ?></td>
                        <td><?= $result['okres_code'] ?></td>
                        <td><?= $result['okres_name'] ?></td>
                        <td><?= $result['obec_code'] ?></td>
                        <td><?= $result['obec_name'] ?></td>
                        <td><?= $result['doc_name'] ?></td>
                        <td><?= $result['doc_street'] ?></td>
                        <td><?= $result['doc_code'] ?></td>
                        <td><?= $result['doc_hours'] ?></td>
                    </tr>
                <?php endforeach; ?>

            <?php endif; ?>


        </table>
    </div>
</div>
<!-- end of results -->