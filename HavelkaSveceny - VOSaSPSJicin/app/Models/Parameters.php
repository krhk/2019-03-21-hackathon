<?php

/**
 * @author Jiří Svěcený <sveceny@sitole.cz>
 * @copyright 2018 Jiří Svěcený
 * @version 13.11.2018
 */

declare(strict_types=1);

namespace App\Models;

use Nette\DI\Container;


class Parameters
{
	/** @var array */
	private $parameters;


	/**
	 * Parameters constructor
	 * @param Container $container
	 */
	public function __construct(Container $container)
	{
		$this->parameters = $container->getParameters();
	}


	/**
	 * Get parameter from container
	 * @param string $parameter
	 * @return mixed|null
	 */
	public function getParameter(string $parameter)
	{
		return $this->parameters[$parameter] ?? null;
	}


	/**
	 * Get list of parameters
	 * @return array
	 */
	public function getParameters()
	{
		return $this->parameters;
	}
}
