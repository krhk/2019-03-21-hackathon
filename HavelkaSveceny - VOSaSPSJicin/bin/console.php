<?php

declare(strict_types=1);

/**
 * @var Nette\DI\Container
 */
$container = require __DIR__ . '/../app/bootstrap.php';

if (!$container instanceof Nette\DI\Container) {
	throw new LogicException('Application container is not defined');
}

$container->getByType(Contributte\Console\Application::class)->run();
