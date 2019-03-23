CREATE TABLE `schools` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`school_code` INT NOT NULL DEFAULT '0',
	`address_code` INT NOT NULL DEFAULT '0',
	`address` VARCHAR(150) NOT NULL DEFAULT '0',
	`branche` VARCHAR(150) NOT NULL DEFAULT '0',
	`branche_name` VARCHAR(150) NOT NULL DEFAULT '0',
	`students` INT NOT NULL DEFAULT '0',
	PRIMARY KEY (`id`)
);
