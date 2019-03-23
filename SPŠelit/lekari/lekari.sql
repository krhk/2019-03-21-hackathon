-- phpMyAdmin SQL Dump
-- version 4.8.4
-- https://www.phpmyadmin.net/
--
-- Počítač: 127.0.0.1
-- Vytvořeno: Čtv 21. bře 2019, 16:54
-- Verze serveru: 10.1.37-MariaDB
-- Verze PHP: 7.3.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Databáze: `lekari`
--

-- --------------------------------------------------------

--
-- Struktura tabulky `details`
--

CREATE TABLE `details` (
  `type` varchar(25) DEFAULT NULL,
  `who` varchar(8) DEFAULT NULL,
  `doc_phone` varchar(17) DEFAULT NULL,
  `okres_code` varchar(10) DEFAULT NULL,
  `okres_name` varchar(19) DEFAULT NULL,
  `obec_code` varchar(8) DEFAULT NULL,
  `obec_name` varchar(22) DEFAULT NULL,
  `doc_name` varchar(86) DEFAULT NULL,
  `doc_street` varchar(15) DEFAULT NULL,
  `doc_code` varchar(13) DEFAULT NULL,
  `doc_hours` varchar(57) DEFAULT NULL,
  `id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Vypisuji data pro tabulku `details`
--

INSERT INTO `details` (`type`, `who`, `doc_phone`, `okres_code`, `okres_name`, `obec_code`, `obec_name`, `doc_name`, `doc_street`, `doc_code`, `doc_hours`, `id`) VALUES
('lékařská pohotovost', 'dospělí', '+420841155155', '3602', 'Hradec Králové', '569810', 'Hradec Králové', 'Fakultní nemocnice Hradec Králové, Pavilon č. 50 Emergency, Oddělení urgentní medicíny', 'Sokolská', '581', 'všední den: 16.00 – 22.00, SO,NE, svátek: 08.00 – 07.00', 2),
('lékařská pohotovost', 'dospělí', '+420841155155', '3602', 'Hradec Králové', '570508', 'Nový Bydžov', 'Oblastní nemocnice Jičín a.s., Areál nemocnice Nový Bydžov', 'Jana Maláta', '493', 'všední den: 15.30 – 07.00, SO, NE, svátek.: nepřetržitě', 3),
('lékařská pohotovost', 'dospělí', '+420841155155', '3605', 'Náchod', '573868', 'Náchod', 'Oblastní nemocnice Náchod a.s.,  Nemocnice Náchod', 'Purkyňova', '446', 'SO,NE, svátek: 08.00 – 20.00', 4),
('lékařská pohotovost', 'dospělí', '+420841155155', '3607', 'Rychnov nad Kněžnou', '576069', 'Rychnov nad Kněžnou', 'Oblastní nemocnice Náchod a.s., Nemocnice Rychnov nad Kněžnou', 'Jiráskova ', '506', 'SO,NE, svátek: 08.00 – 20.00', 5),
('lékařská pohotovost', 'dospělí', '+420841155155', '3604', 'Jičín', '572659', 'Jičín', 'Oblastní nemocnice Jičín a.s.', 'Bolzanova', '512', 'SO,NE, svátek: 08.00 – 20.00', 6),
('lékařská pohotovost', 'dospělí', '+420841155155', '3610', 'Trutnov', '579025', 'Trutnov', 'Oblastní nemocnice Trutnov a.s.', 'Maxima Gorkého', '77', 'SO,NE, svátek: 08.00 – 20.00', 7),
('lékařská pohotovost', 'děti', '+420841155155', '3602', 'Hradec Králové', '569810', 'Hradec Králové', 'Fakultní nemocnice Hradec Králové, Pavilon č. 18 Dětská klinika', 'Sokolská', '581', 'všední den: 15.30 - 22.00, SO, NE, svátek: 08.00 – 22.00 ', 8),
('lékařská pohotovost', 'děti', '+420841155155', '3602', 'Hradec Králové', '570508', 'Nový Bydžov', 'Oblastní nemocnice Jičín a.s., Areál nemocnice Nový Bydžov', 'Jana Maláta', '493', 'všední den: 15.30 – 07.00, SO, NE, svátek.: nepřetržitě ', 9),
('lékařská pohotovost', 'děti', '+420841155155', '3605', 'Náchod', '573868', 'Náchod', 'Oblastní nemocnice Náchod a.s.', 'Bartoňova', '951', 'všední den: 16.00 - 22.00, SO, NE, svátek: 08.00 – 22.00 ', 10),
('lékařská pohotovost', 'děti', '+420841155155', '3607', 'Rychnov nad Kněžnou', '576069', 'Rychnov nad Kněžnou', 'Oblastní nemocnice Náchod a.s., Nemocnice Rychnov nad Kněžnou', 'Jiráskova ', '506', 'všední den: 15.30 - 07.00, SO, NE, svátek: 08.00 – 20.00 ', 11),
('lékařská pohotovost', 'děti', '+420841155155', '3604', 'Jičín', '572659', 'Jičín', 'Oblastní nemocnice Jičín a.s.', 'Bolzanova ', '512', 'všední den: 16.00 - 20.00, SO, NE, svátek: 08.00 – 20.00 ', 12),
('lékařská pohotovost', 'děti', '+420841155155', '3610', 'Trutnov', '579025', 'Trutnov', 'Oblastní nemocnice Trutnov a.s.', 'Maxima Gorkého ', '77', 'všední den: 16.00 - 20.00, SO, NE, svátek: 08.00 – 20.00 ', 13),
('lékařská pohotovost', 'děti', '+420841155155', '3610', 'Trutnov', '579203', 'Dvůr Králové nad Labem', 'Městská nemocnice a.s. ', 'Vrchlického', '1504', 'SO, NE, svátek: 08.00 – 20.00 ', 14),
('stomatologická pohotovost', 'všichni', '', '3602', 'Hradec Králové', '569810', 'Hradec Králové', 'Fakultní nemocnice Hradec Králové, budova č. 11 Stomatologická klinika ', '', '', 'všední den: 16.00 – 22.00, SO,NE, svátek: 08.00 – 22.00', 15),
('stomatologická pohotovost', 'všichni', '', '3602', 'Hradec Králové', '570508', 'Nový Bydžov', 'privátní lékaři dle aktuálního rozpisu', '', '', 'SO,NE, svátek: 07.00 – 13.00', 16),
('stomatologická pohotovost', 'všichni', '', '3605', 'Náchod', '573868', 'Náchod', 'privátní lékaři dle aktuálního rozpisu', '', '', 'SO,NE, svátek: 08.00 – 12.00', 17),
('stomatologická pohotovost', 'všichni', '', '3605', 'Náchod', '574082', 'Hronov', 'privátní lékaři dle aktuálního rozpisu', '', '', 'SO,NE, svátek: 08.00 – 12.00', 18),
('stomatologická pohotovost', 'všichni', '', '3605', 'Náchod', '573965', 'Červený Kostelec', 'privátní lékaři dle aktuálního rozpisu', '', '', 'SO,NE, svátek: 08.00 – 12.00', 19),
('stomatologická pohotovost', 'všichni', '', '3605', 'Náchod', '574279', 'Nové Město nad Metují', 'privátní lékaři dle aktuálního rozpisu', '', '', 'SO,NE, svátek: 08.00 – 12.00', 20),
('stomatologická pohotovost', 'všichni', '', '3605', 'Náchod', '573922', 'Broumov', 'privátní lékaři dle aktuálního rozpisu', '', '', 'SO,NE, svátek: 09.00 – 11.00', 21),
('stomatologická pohotovost', 'všichni', '', '3605', 'Náchod', '574341', 'Police nad Metují', 'privátní lékaři dle aktuálního rozpisu', '', '', 'SO,NE, svátek: 09.00 – 11.00', 22),
('stomatologická pohotovost', 'všichni', '', '3605', 'Náchod', '574210', 'Machov', 'privátní lékaři dle aktuálního rozpisu', '', '', 'SO,NE, svátek: 09.00 – 11.00', 23),
('stomatologická pohotovost', 'všichni', '', '3605', 'Náchod', '574121', 'Jaroměř', 'privátní lékaři dle aktuálního rozpisu', '', '', 'SO,NE, svátek: 08.00 – 10.00', 24),
('stomatologická pohotovost', 'všichni', '', '3605', 'Náchod', '573990', 'Česká Skalice', 'privátní lékaři dle aktuálního rozpisu', '', '', 'SO,NE, svátek: 08.00 – 10.00', 25),
('stomatologická pohotovost', 'všichni', '', '3607', 'Rychnov nad Kněžnou', '576069', 'Rychnov nad Kněžnou', 'privátní lékaři dle aktuálního rozpisu', '', '', 'SO,NE, svátek: 08.00 – 12.00', 26),
('stomatologická pohotovost', 'všichni', '', '3604', 'Jičín', '572659', 'Jičín', 'privátní lékaři dle aktuálního rozpisu', '', '', 'SO,NE, svátek: 08.00 – 12.00', 27),
('stomatologická pohotovost', 'všichni', '', '3610', 'Trutnov', '579025', 'Trutnov', 'privátní lékaři dle aktuálního rozpisu', '', '', 'SO,NE, svátek: 08.00 – 12.00', 28),
('stomatologická pohotovost', 'všichni', '', '3610', 'Trutnov', '579858', 'Vrchlabí', 'privátní lékaři dle aktuálního rozpisu', '', '', 'SO,NE, svátek: 08.00 – 12.00', 29),
('stomatologická pohotovost', 'všichni', '', '3610', 'Trutnov', '579203', 'Dvůr Králové nad Labem', 'privátní lékaři dle aktuálního rozpisu', '', '', 'SO,NE, svátek: 08.00 – 12.00', 30),
('lékárenská pohotovost', 'všichni', '', '3602', 'Hradec Králové', '569810', 'Hradec Králové', 'Nemocniční lékárna Fakultní nemocnice Hradec Králové ', '', '', 'všední den: 16.00 – 07.00, SO,NE, svátek: nepretržitě', 31);

--
-- Klíče pro exportované tabulky
--

--
-- Klíče pro tabulku `details`
--
ALTER TABLE `details`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT pro tabulky
--

--
-- AUTO_INCREMENT pro tabulku `details`
--
ALTER TABLE `details`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=32;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
