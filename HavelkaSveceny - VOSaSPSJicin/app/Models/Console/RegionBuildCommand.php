<?php

/**
 * @author Jiří Svěcený <sveceny@sitole.cz>
 * @copyright 2019 Jiří Svěcený
 * @version 21.03.2019
 */

declare(strict_types=1);

namespace App\Models\Console;

use App\Models\Parameters;
use Nette\Utils\FileSystem;
use Nette\Utils\Json;
use Nette\Utils\Strings;
use Symfony\Component\Console\Command\Command;
use Symfony\Component\Console\Input\InputInterface;
use Symfony\Component\Console\Output\OutputInterface;


class RegionBuildCommand extends Command
{
	/** @var string */
	private const ENDPOINT = 'https://nominatim.openstreetmap.org/search.php?q=%s&polygon_geojson=1&format=json';

	/** @var string */
	protected static $defaultName = "build:regions";

	/** @var Parameters */
	private $parameters;


	/**
	 * RegionBuildCommand constructor
	 * @param Parameters $parameters
	 * @param string|null $name
	 */
	public function __construct(Parameters $parameters, string $name = null)
	{
		parent::__construct($name);
		$this->parameters = $parameters;
	}


	/**
	 * Create point structures
	 * @param InputInterface $input
	 * @param OutputInterface $output
	 */
	protected function execute(InputInterface $input, OutputInterface $output)
	{
		$regions = [
			"Trutnov",
			"Jičín",
			"Náchod",
			"Hradec Králové",
			"Rychnov nad Kněžnou",
		];

		foreach ($regions as $region) {
			$outputFile = $this->parameters->getParameter("appDir") . "/../www/build/regions/" . Strings::webalize($region) . ".json";

			// Request headers
			$address = sprintf(self::ENDPOINT, urlencode("Okres " . $region));
			$context = [
				"http" => [
					"header" => "User-Agent: Mozilla/5.0 (Windows NT 10.0; WOW64) Chrome/50.0.2661.102 Safari/537.36",
				],
			];

			// Parse coordinates
			$json = Json::decode(file_get_contents($address, false, stream_context_create($context)));
			FileSystem::write($outputFile, Json::encode($json[0]->geojson));
		}

        $outputFile = $this->parameters->getParameter("appDir") . "/../www/build/regions/HK.json";
        // Request headers
        $address = sprintf(self::ENDPOINT, urlencode("Kralovehradecky kraj"));
        $context = [
            "http" => [
                "header" => "User-Agent: Mozilla/5.0 (Windows NT 10.0; WOW64) Chrome/50.0.2661.102 Safari/537.36",
            ],
        ];
        // Parse coordinates
        $json = Json::decode(file_get_contents($address, false, stream_context_create($context)));
        FileSystem::write($outputFile, Json::encode($json[0]->geojson));


		$output->writeln("Region parser finished");
	}
}
