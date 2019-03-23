<?php

/**
 * @author Jiří Svěcený <sveceny@sitole.cz>
 * @copyright 2018 Jiří Svěcený
 * @version 17.07.2018
 */

declare(strict_types=1);

namespace App\Factories;

use Nette\Application\IRouter;
use Nette\Application\Routers\Route;
use Nette\Application\Routers\RouteList;


final class RouterFactory
{
	/**
	 * Return list of routes in application
	 * @return IRouter
	 */
	public static function create(): IRouter
	{
		$router = new RouteList;

		$router[] = new Route("", "Frontend:Home:Default");

		// Api module
		$router[] = new Route("api/regions", "Api:Regions:Default");
        $router[] = new Route("api/schools/branches/[<region>]", "Api:Schools:Branches");
		$router[] = new Route("api/schools/[<region>]", "Api:Schools:Default");

		$router[] = new Route("api/branches/[<region>]", "Api:Branches:Default");


		return $router;
	}
}
