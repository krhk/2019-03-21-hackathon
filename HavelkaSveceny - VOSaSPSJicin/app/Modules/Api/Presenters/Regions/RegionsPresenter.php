<?php

/**
 * @author Jiří Svěcený <sveceny@sitole.cz>
 * @copyright 2019 Jiří Svěcený
 * @version 21.03.2019
 */

declare(strict_types=1);

namespace App\Modules\Api\Presenters\Regions;

use App\Models\Parameters;
use App\Modules\Api\ApiPresenter;
use Nextras\Dbal\Connection;


class RegionsPresenter extends ApiPresenter
{
    /**
     * @var Connection
     * @inject
     */
    public $conection;

    /**
     * @var Parameters
     * @inject
     */
    public $parameters;


    /**
     * Api endpoint for list of regions
     */
    public function actionDefault(): void
    {
        $regions = $this->conection->query("SELECT * FROM regions")->fetchAll();
        $this->sendJson($regions);
    }
}
