<?php

/**
 * @author Jiří Svěcený <sveceny@sitole.cz>
 * @copyright 2018 Jiří Svěcený
 * @version 08.11.2018
 */

declare(strict_types=1);

namespace App\Presenters\Error;

use App\Models\UI\BasePresenter;
use Nette\Application;
use NetteModule;
use Tracy\ILogger;


class ErrorPresenter extends BasePresenter
{
	/**
	 * @var ILogger
	 * @inject
	 */
	public $logger;


	/**
	 * Processes a error request
	 * @param Application\Request $request
	 * @return Application\IResponse
	 */
	public function run(Application\Request $request): Application\IResponse
	{
		$exception = $request->getParameter('exception');

		// Manage bad ajax request
		if ($this->ajax) {
			return new Application\Responses\JsonResponse(['error' => true]);
		}

		// Handle bad request
		if ($exception instanceof Application\BadRequestException) {
			$this->logger->log('HTTP code ' . $exception->getHttpCode(), ILogger::INFO);

			return new Application\Responses\TextResponse(
				$this->template->renderToString(__DIR__ . '/templates/404.latte')
			);
		}

		// Some dark magic to get presenter
		return (new NetteModule\ErrorPresenter($this->logger))->run($request);
	}
}
