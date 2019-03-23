<?php

/**
 * @author Jiří Svěcený <sveceny@sitole.cz>
 * @copyright 2019 Jiří Svěcený
 * @version 21.03.2019
 */

declare(strict_types=1);

namespace App\Models\Console;

use App\External\XLSXReader;
use App\Models\Parameters;
use Nextras\Dbal\Connection;
use SimpleXLSX;
use Symfony\Component\Console\Command\Command;
use Symfony\Component\Console\Input\InputInterface;
use Symfony\Component\Console\Output\OutputInterface;


class SchoolsBuildCommand extends Command
{
	/** @var string */
	protected static $defaultName = 'build:schools';

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
		$file = $this->parameters->getParameter("appDir") . "/../www/build/school-overview.csv";
		$this->connection->transactional(
			function (Connection $connection) use ($file, $output): void {
				$row = 0;
				$handle = fopen($file, "r");

				if ($handle !== false) {
					while (($data = fgetcsv($handle, 1000, ",")) !== false) {
						$data = array_map("utf8_encode", $data); //added

						$row++;

						// Skip header
						if ($row === 1) {
							continue;
						}

						// TODO: Shit neni cas #delamOstuduPhpKomunite
						$replaceData = [
							"Jièín" => "Jičín",
							"Hoøice" => "Hořice",
							"Hluice" => "Hlušice",
							"Smiøice" => "Smiřice",
							"Dvùr Králové nad Labem" => "Dvůr Králové nad Labem",
							"Jaromìø" => "Jaroměř",
						];

						if (isset($data[6]) === true) {
							$city = $data[2];

							foreach ($replaceData as $old => $new) {
								$city = str_replace($old, $new, $city);
							}

							// Insert schools
							$connection->query('INSERT INTO schools %values', [
								'school_code' => (int) $data[0],
								'address_code' => (int) $data[1],
								'address' => $city,
								'branche' => $data[4],
								'branche_name' => $data[5],
								'students' => (int) $data[6],
							]);
						}
					}
				}
			}
		);

		$output->writeln("School build finished");
	}
}
