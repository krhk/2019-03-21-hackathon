<?php

/**
 * @author Jiří Svěcený <sveceny@sitole.cz>
 * @copyright 2019 Jiří Svěcený
 * @version 21.03.2019
 */

declare(strict_types=1);

namespace App\Models\Console;

use App\Models\Parameters;
use Nette\Utils\Json;
use Nextras\Dbal\Connection;
use SimpleXMLElement;
use Symfony\Component\Console\Command\Command;
use Symfony\Component\Console\Input\InputInterface;
use Symfony\Component\Console\Output\OutputInterface;


class BranchesBuildCommand extends Command
{
	/** @var string */
	protected static $defaultName = 'build:branches';

	/** @var Parameters */
	private $parameters;

	/** @var Connection */
	private $connection;


	/**
	 * BranchesBuildCommand constructor
	 * @param Connection $connection
	 * @param Parameters $parameters
	 * @param string|null $name
	 */
	public function __construct(Connection $connection, Parameters $parameters, string $name = null)
	{
		parent::__construct($name);
		$this->parameters = $parameters;
		$this->connection = $connection;
	}


	/**
	 * @param InputInterface $input
	 * @param OutputInterface $output
	 */
	protected function execute(InputInterface $input, OutputInterface $output)
	{
		$file = $this->parameters->getParameter("appDir") . "/../www/build/schools.csv";
		$this->connection->transactional(
			function (Connection $connection) use ($file, $output): void {

				$regionsPolygons = [];
				$sources = $connection->query("SELECT * FROM regions")->fetchPairs("id", "slug");

				// Load polygon files
				foreach ($sources as $source) {
					$json = file_get_contents(
						$this->parameters->getParameter('appDir') . "/../www/build/regions/{$source}.json"
					);

					$regionsPolygons[$source] = Json::decode($json)->coordinates[0];
				}

				$row = 0;
				$handle = fopen($file, "r");

				if ($handle !== false) {
					while (($data = fgetcsv($handle, 1000, ",")) !== false) {
						$row++;

						// Skip header
						if ($row === 1) {
							continue;
						}

						// Request headers
						$address = sprintf("https://api.mapy.cz/geocode?query=%s", urlencode($data[2]));
						$context = [
							"http" => [
								"header" => "User-Agent: Mozilla/5.0 (Windows NT 10.0; WOW64) Chrome/50.0.2661.102 Safari/537.36",
							],
						];

						$xml = file_get_contents($address, false, stream_context_create($context));
						$element = new SimpleXMLElement($xml);
						$region = null;

						$x = 0;
						$y = 0;

						foreach ($element as $points) {
							foreach ($points as $point) {
								$x = $point->attributes()["x"];
								$y = $point->attributes()["y"];
							}
						}

						// Find region by position
						foreach ($regionsPolygons as $name => $coordinates) {
							$inside = $this->isInside([$x, $y], $coordinates);
							$region = null;

							if ($inside) {
								$region = $name;
								break;
							}
						}

						// Insert new branche
						$connection->query('INSERT INTO branches %values', [
							'resort' => (int) $data[0],
							'school' => (int) $data[1],
							'address' => $data[2],
							'address_code' => (int) $data[3],
							'branch_code' => $data[4],
							'branch' => $data[5],
							"region" => $region,
							'map_x' => $x,
							'map_y' => $y,
						]);
					}

					fclose($handle);
				}

				$output->writeln("Branches build finished");
			}
		);
	}


	// https://stackoverflow.com/questions/22521982/check-if-point-inside-a-polygon
	public function isInside($point, $polygons)
	{
		$x = $point[0];
		$y = $point[1];
		$inside = false;
		for ($i = 0, $j = sizeof($polygons) - 1; $i < sizeof($polygons); $j = $i++) {
			$xi = $polygons[$i][0];
			$yi = $polygons[$i][1];
			$xj = $polygons[$j][0];
			$yj = $polygons[$j][1];

			$intersect = (($yi > $y) != ($yj > $y)) && ($x < ($xj - $xi) * ($y - $yi) / ($yj - $yi) + $xi);
			if ($intersect) $inside = !$inside;
		}
		return $inside;
	}










}
