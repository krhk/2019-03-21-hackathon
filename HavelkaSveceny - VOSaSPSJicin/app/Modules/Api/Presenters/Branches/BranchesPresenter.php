<?php

/**
 * @author Jiří Svěcený <sveceny@sitole.cz>
 * @copyright 2019 Jiří Svěcený
 * @version 21.03.2019
 */

declare(strict_types=1);

namespace App\Modules\Api\Presenters\Branches;

use App\Modules\Api\ApiPresenter;
use Nextras\Dbal\Connection;


class BranchesPresenter extends ApiPresenter
{
	/**
	 * @var Connection
	 * @inject
	 */
	public $conection;


	/**
	 * Get school branches by region
	 * @param string|null $region
	 */
	public function actionDefault(string $region = null): void
	{
		if ($region === null) {
			$data = $this->conection->query("SELECT * FROM branches WHERE region IS NOT NULL")->fetchAll();
		} else {
			$data = $this->conection->query("SELECT * FROM branches WHERE region = %s", $region)->fetchAll();
		}

		$this->sendJson($data);
	}
}
