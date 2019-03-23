<?php

/**
 * @author Jiří Svěcený <sveceny@sitole.cz>
 * @copyright 2019 Jiří Svěcený
 * @version 21.03.2019
 */

declare(strict_types=1);

namespace App\Modules\Api\Presenters\Schools;

use App\Modules\Api\ApiPresenter;
use Nextras\Dbal\Connection;


class SchoolsPresenter extends ApiPresenter
{
    /**
     * @var Connection
     * @inject
     */
    public $conection;


    /**
     * Get schools by region
     * @param string|null $region
     */
    public function actionDefault(string $region = null): void
    {
        if ($region === null) {
            $data = $this->conection->query("SELECT * FROM branches WHERE region IS NOT NULL GROUP BY address_code ORDER BY address")->fetchAll();
        } else {
            $data = $this->conection->query("SELECT * FROM branches WHERE region = %s GROUP BY address_code ORDER BY address", $region)->fetchAll();
        }

        $this->sendJson($data);
    }

    public function actionBranches(string $region = null): void
    {

        if ($region === null) {
            $data = $this->conection->query("SELECT COUNT(branch) AS rank, (Count(branch)* 100 / (Select Count(*) From branches)) as percantage, branch FROM branches GROUP BY branches.branch  ORDER BY rank DESC LIMIT 5 ")->fetchAll();
        } else {
            $data = $this->conection->query("SELECT COUNT(branch) AS rank, (Count(branch)* 100 / (Select Count(*) From branches)) as percantage, branch FROM branches WHERE region=%s  GROUP BY  branches.branch ORDER BY rank DESC LIMIT 5", $region)->fetchAll();
        }

        $this->sendJson($data);
    }

}
