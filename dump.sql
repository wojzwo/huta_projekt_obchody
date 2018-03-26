-- MySQL dump 10.16  Distrib 10.1.26-MariaDB, for debian-linux-gnu (x86_64)
--
-- Host: localhost    Database: hutadb
-- ------------------------------------------------------
-- Server version	10.1.26-MariaDB-0+deb9u1

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `ArchiveReport`
--

DROP TABLE IF EXISTS `ArchiveReport`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ArchiveReport` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `routineId` int(11) NOT NULL,
  `assignmentDate` date NOT NULL,
  `signedEmployeeName` varchar(127) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `trackName` varchar(255) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `shift` int(11) NOT NULL,
  `isFinished` bit(1) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=91 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ArchiveReport`
--

LOCK TABLES `ArchiveReport` WRITE;
/*!40000 ALTER TABLE `ArchiveReport` DISABLE KEYS */;
INSERT INTO `ArchiveReport` VALUES (24,5,'2018-03-19','','Trasa testowa',2,'\0'),(25,5,'2018-03-19','Stanisław Nowak2','Trasa testowa',3,''),(26,5,'2018-03-19','','Trasa testowa',1,'\0'),(32,5,'2018-03-19','Stanisław Nowak2','Trasa testowa',2,''),(33,5,'2018-03-19','','Trasa testowa',3,'\0'),(34,5,'2018-03-19','Stanisław Nowak2','Trasa testowa',1,''),(35,6,'2018-03-19','Stanisław Nowak2','Trasa testowa 2',2,''),(36,6,'2018-03-19','Stanisław Nowak2','Trasa testowa 2',3,''),(58,8,'2018-03-24','Grupa 1','Trasa testowa',2,'\0'),(59,11,'2018-03-24','','Trasa testowa 2',2,'\0'),(60,12,'2018-03-24','Stanisław Nowak2','Trasa testowa 2',3,''),(61,7,'2018-03-24','','Trasa testowa',1,'\0'),(62,8,'2018-03-24','Grupa 1','Trasa testowa',2,'\0'),(63,11,'2018-03-24','','Trasa testowa 2',2,'\0'),(64,12,'2018-03-24','Grupa 1','Trasa testowa 2',3,'\0'),(65,8,'2018-03-24','Grupa 1','Trasa testowa',2,'\0'),(66,11,'2018-03-24','--Dowolny pracownik--','Trasa testowa 2',2,'\0'),(67,12,'2018-03-24','Grupa 1','Trasa testowa 2',3,'\0'),(68,8,'2018-03-24','Grupa: Grupa 1','Trasa testowa',2,'\0'),(69,11,'2018-03-24','Grupa: --Dowolny pracownik--','Trasa testowa 2',2,'\0'),(70,12,'2018-03-24','Grupa: Grupa 1','Trasa testowa 2',3,'\0'),(71,8,'2018-03-24','Grupa: Grupa 1','Trasa testowa',2,'\0'),(72,11,'2018-03-24','Grupa: --Dowolny pracownik--','Trasa testowa 2',2,'\0'),(73,12,'2018-03-24','Grupa: Grupa 1','Trasa testowa 2',3,'\0'),(74,8,'2018-03-24','Grupa: Grupa 1','Trasa testowa',2,'\0'),(75,11,'2018-03-24','Grupa: --Dowolny pracownik--','Trasa testowa 2',2,'\0'),(76,12,'2018-03-24','Grupa: Grupa 1','Trasa testowa 2',3,'\0'),(77,8,'2018-03-24','Grupa: Grupa 1','Trasa testowa',2,'\0'),(78,11,'2018-03-24','Grupa: --Dowolny pracownik--','Trasa testowa 2',2,'\0'),(79,12,'2018-03-24','Grupa: Grupa 1','Trasa testowa 2',3,'\0'),(80,8,'2018-03-24','Stanisław Nowak2','Trasa testowa',2,''),(81,11,'2018-03-24','Grupa: --Dowolny pracownik--','Trasa testowa 2',2,'\0'),(82,12,'2018-03-24','Grupa: Grupa 1','Trasa testowa 2',3,'\0'),(83,8,'2018-03-24','Grupa: Grupa 1','Trasa testowa',2,'\0'),(84,11,'2018-03-24','Grupa: --Dowolny pracownik--','Trasa testowa 2',2,'\0'),(85,12,'2018-03-24','Grupa: Grupa 1','Trasa testowa 2',3,'\0'),(86,9,'2018-03-25','Grupa: --Dowolny pracownik--','Trasa testowa',3,'\0'),(87,10,'2018-03-25','Grupa: --Dowolny pracownik--','Trasa testowa 2',1,'\0'),(88,11,'2018-03-25','Grupa: --Dowolny pracownik--','Trasa testowa 2',2,'\0'),(89,12,'2018-03-25','Grupa: Grupa 1','Trasa testowa 2',3,'\0'),(90,13,'2018-03-25','Grupa: --Dowolny pracownik--','Trasa testowa 2',3,'\0');
/*!40000 ALTER TABLE `ArchiveReport` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ArchiveReportPlace`
--

DROP TABLE IF EXISTS `ArchiveReportPlace`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ArchiveReportPlace` (
  `reportId` bigint(20) NOT NULL,
  `placeName` varchar(255) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `status` varchar(127) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `markDescription` varchar(127) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `comment` varchar(511) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `department` varchar(127) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `visitDate` datetime NOT NULL,
  `markCommentRequired` bit(1) NOT NULL,
  PRIMARY KEY (`reportId`,`placeName`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ArchiveReportPlace`
--

LOCK TABLES `ArchiveReportPlace` WRITE;
/*!40000 ALTER TABLE `ArchiveReportPlace` DISABLE KEYS */;
INSERT INTO `ArchiveReportPlace` VALUES (24,'Rozdzielnica RSP','','','','Odlewnia','0001-01-01 00:00:00','\0'),(25,'Rozdzielnica RSP','Odwiedzono','Wszystko w porządku','','Odlewnia','2018-03-19 17:53:00','\0'),(26,'Rozdzielnica RSP','','','','Odlewnia','0001-01-01 00:00:00','\0'),(32,'Rozdzielnica RSP','Odwiedzono','Wszystko w porządku','','Odlewnia','2018-03-19 18:34:00','\0'),(33,'Rozdzielnica RSP','','','','Odlewnia','0001-01-01 00:00:00','\0'),(34,'Rozdzielnica RSP','Odwiedzono','Wszystko w porządku','','Odlewnia','2018-03-19 18:35:00','\0'),(35,'Agregat Diesla','Nieodwiedzono','Wszystko w porządku','Było spoko, tylko chip się zbugował','Walcownia','2018-03-19 18:35:00','\0'),(35,'Lodówka','Odwiedzono - Poprawiano ocenę','Wszystko w porządku','','Biuro','2018-03-19 18:35:00','\0'),(36,'Agregat Diesla','Odwiedzono - Poprawiano miejsce','Awaria','YYY, Coś dmuchło, a nie byłem bo chip mi wpadł do lawy','Walcownia','2018-03-19 18:36:00',''),(36,'Lodówka','Odwiedzono - Poprawiano ocenę','Wszystko w porządku','Gut gud','Biuro','2018-03-19 18:36:00','\0'),(58,'Rozdzielnica RSP','Nieodwiedzono','','','Odlewnia','0001-01-01 00:00:00','\0'),(59,'Agregat Diesla','Nieodwiedzono','','','Walcownia','0001-01-01 00:00:00','\0'),(59,'Lodówka','Nieodwiedzono','','','Biuro','0001-01-01 00:00:00','\0'),(60,'Agregat Diesla','Nieodwiedzono','Awaria','Nie byłem, coś pierdolło','Walcownia','2018-03-24 15:08:00',''),(60,'Lodówka','Nieodwiedzono','Wszystko w porządku','Nie byłem','Biuro','2018-03-24 15:08:00','\0'),(61,'Rozdzielnica RSP','Nieodwiedzono','','','Odlewnia','0001-01-01 00:00:00','\0'),(62,'Rozdzielnica RSP','Nieodwiedzono','','','Odlewnia','0001-01-01 00:00:00','\0'),(63,'Agregat Diesla','Nieodwiedzono','','','Walcownia','0001-01-01 00:00:00','\0'),(63,'Lodówka','Nieodwiedzono','','','Biuro','0001-01-01 00:00:00','\0'),(64,'Agregat Diesla','Nieodwiedzono','','','Walcownia','0001-01-01 00:00:00','\0'),(64,'Lodówka','Nieodwiedzono','','','Biuro','0001-01-01 00:00:00','\0'),(65,'Rozdzielnica RSP','Nieodwiedzono','','','Odlewnia','0001-01-01 00:00:00','\0'),(66,'Agregat Diesla','Nieodwiedzono','','','Walcownia','0001-01-01 00:00:00','\0'),(66,'Lodówka','Nieodwiedzono','','','Biuro','0001-01-01 00:00:00','\0'),(67,'Agregat Diesla','Nieodwiedzono','','','Walcownia','0001-01-01 00:00:00','\0'),(67,'Lodówka','Nieodwiedzono','','','Biuro','0001-01-01 00:00:00','\0'),(68,'Rozdzielnica RSP','Nieodwiedzono','','','Odlewnia','0001-01-01 00:00:00','\0'),(69,'Agregat Diesla','Nieodwiedzono','','','Walcownia','0001-01-01 00:00:00','\0'),(69,'Lodówka','Nieodwiedzono','','','Biuro','0001-01-01 00:00:00','\0'),(70,'Agregat Diesla','Nieodwiedzono','','','Walcownia','0001-01-01 00:00:00','\0'),(70,'Lodówka','Nieodwiedzono','','','Biuro','0001-01-01 00:00:00','\0'),(71,'Rozdzielnica RSP','Nieodwiedzono','','','Odlewnia','0001-01-01 00:00:00','\0'),(72,'Agregat Diesla','Nieodwiedzono','','','Walcownia','0001-01-01 00:00:00','\0'),(72,'Lodówka','Nieodwiedzono','','','Biuro','0001-01-01 00:00:00','\0'),(73,'Agregat Diesla','Nieodwiedzono','','','Walcownia','0001-01-01 00:00:00','\0'),(73,'Lodówka','Nieodwiedzono','','','Biuro','0001-01-01 00:00:00','\0'),(74,'Rozdzielnica RSP','Nieodwiedzono','','','Odlewnia','0001-01-01 00:00:00','\0'),(75,'Agregat Diesla','Nieodwiedzono','','','Walcownia','0001-01-01 00:00:00','\0'),(75,'Lodówka','Nieodwiedzono','','','Biuro','0001-01-01 00:00:00','\0'),(76,'Agregat Diesla','Nieodwiedzono','','','Walcownia','0001-01-01 00:00:00','\0'),(76,'Lodówka','Nieodwiedzono','','','Biuro','0001-01-01 00:00:00','\0'),(77,'Rozdzielnica RSP','Nieodwiedzono','','','Odlewnia','0001-01-01 00:00:00','\0'),(78,'Agregat Diesla','Nieodwiedzono','','','Walcownia','0001-01-01 00:00:00','\0'),(78,'Lodówka','Nieodwiedzono','','','Biuro','0001-01-01 00:00:00','\0'),(79,'Agregat Diesla','Nieodwiedzono','','','Walcownia','0001-01-01 00:00:00','\0'),(79,'Lodówka','Nieodwiedzono','','','Biuro','0001-01-01 00:00:00','\0'),(80,'Rozdzielnica RSP','Odwiedzono','Wszystko w porządku','','Odlewnia','2018-03-24 16:42:00','\0'),(81,'Agregat Diesla','Nieodwiedzono','','','Walcownia','0001-01-01 00:00:00','\0'),(81,'Lodówka','Nieodwiedzono','','','Biuro','0001-01-01 00:00:00','\0'),(82,'Agregat Diesla','Nieodwiedzono','','','Walcownia','0001-01-01 00:00:00','\0'),(82,'Lodówka','Nieodwiedzono','','','Biuro','0001-01-01 00:00:00','\0'),(83,'Rozdzielnica RSP','Nieodwiedzono','','','Odlewnia','0001-01-01 00:00:00','\0'),(84,'Agregat Diesla','Nieodwiedzono','','','Walcownia','0001-01-01 00:00:00','\0'),(84,'Lodówka','Nieodwiedzono','','','Biuro','0001-01-01 00:00:00','\0'),(85,'Agregat Diesla','Nieodwiedzono','','','Walcownia','0001-01-01 00:00:00','\0'),(85,'Lodówka','Nieodwiedzono','','','Biuro','0001-01-01 00:00:00','\0'),(86,'Rozdzielnica RSP','Nieodwiedzono','','','Odlewnia','0001-01-01 00:00:00','\0'),(87,'Agregat Diesla','Nieodwiedzono','','','Walcownia','0001-01-01 00:00:00','\0'),(87,'Lodówka','Nieodwiedzono','','','Biuro','0001-01-01 00:00:00','\0'),(88,'Agregat Diesla','Nieodwiedzono','','','Walcownia','0001-01-01 00:00:00','\0'),(88,'Lodówka','Nieodwiedzono','','','Biuro','0001-01-01 00:00:00','\0'),(89,'Agregat Diesla','Nieodwiedzono','','','Walcownia','0001-01-01 00:00:00','\0'),(89,'Lodówka','Nieodwiedzono','','','Biuro','0001-01-01 00:00:00','\0'),(90,'Agregat Diesla','Nieodwiedzono','','','Walcownia','0001-01-01 00:00:00','\0'),(90,'Lodówka','Nieodwiedzono','','','Biuro','0001-01-01 00:00:00','\0');
/*!40000 ALTER TABLE `ArchiveReportPlace` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Chip`
--

DROP TABLE IF EXISTS `Chip`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Chip` (
  `chipId` varchar(31) NOT NULL,
  `isEmployee` bit(1) NOT NULL,
  PRIMARY KEY (`chipId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Chip`
--

LOCK TABLES `Chip` WRITE;
/*!40000 ALTER TABLE `Chip` DISABLE KEYS */;
INSERT INTO `Chip` VALUES ('213213','\0'),('EFA62D',''),('EFD576',''),('F06516','\0'),('F0D8B4',''),('F0DFC9','\0'),('F0E0EE','\0');
/*!40000 ALTER TABLE `Chip` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Employee`
--

DROP TABLE IF EXISTS `Employee`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Employee` (
  `chipId` varchar(31) NOT NULL,
  `name` varchar(127) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`chipId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Employee`
--

LOCK TABLES `Employee` WRITE;
/*!40000 ALTER TABLE `Employee` DISABLE KEYS */;
INSERT INTO `Employee` VALUES ('EFA62D','Jakub Dominikanin'),('EFD576','Stanisław Nowak2'),('F0D8B4','Piotr Kowalski');
/*!40000 ALTER TABLE `Employee` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Mail`
--

DROP TABLE IF EXISTS `Mail`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Mail` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `address` varchar(255) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `isFullReport` bit(1) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Mail`
--

LOCK TABLES `Mail` WRITE;
/*!40000 ALTER TABLE `Mail` DISABLE KEYS */;
INSERT INTO `Mail` VALUES (1,'huta.raporty@gmail.com',''),(2,'thirrasch@gmail.com','\0'),(3,'wojciech.zwolinski0@gmail.com',''),(4,'wojciech.zwolinski0@gmail.com','\0');
/*!40000 ALTER TABLE `Mail` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Mark`
--

DROP TABLE IF EXISTS `Mark`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Mark` (
  `id` int(11) NOT NULL,
  `description` varchar(127) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `requiresComment` bit(1) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Mark`
--

LOCK TABLES `Mark` WRITE;
/*!40000 ALTER TABLE `Mark` DISABLE KEYS */;
INSERT INTO `Mark` VALUES (0,'Problem 0',''),(1,'Wszystko w porządku','\0'),(2,'Awaria',''),(3,'Problem 3',''),(4,'Problem 4',''),(5,'Problem 5',''),(6,'Problem 6',''),(7,'Problem 7',''),(8,'Problem 8',''),(9,'Problem 9',''),(12,'Problem C',''),(14,'Problem E','');
/*!40000 ALTER TABLE `Mark` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Place`
--

DROP TABLE IF EXISTS `Place`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Place` (
  `chipId` varchar(31) NOT NULL,
  `name` varchar(255) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `department` varchar(127) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`chipId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Place`
--

LOCK TABLES `Place` WRITE;
/*!40000 ALTER TABLE `Place` DISABLE KEYS */;
INSERT INTO `Place` VALUES ('213213','Piekarnik',''),('F06516','Rozdzielnica RSP','Odlewnia'),('F0DFC9','Lodówka','Biuro'),('F0E0EE','Agregat Diesla','Walcownia');
/*!40000 ALTER TABLE `Place` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Report`
--

DROP TABLE IF EXISTS `Report`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Report` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `routineId` int(11) NOT NULL,
  `assignmentDate` date NOT NULL,
  `signedEmployeeName` varchar(127) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `trackName` varchar(255) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `shift` int(11) NOT NULL,
  `isFinished` bit(1) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=93 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Report`
--

LOCK TABLES `Report` WRITE;
/*!40000 ALTER TABLE `Report` DISABLE KEYS */;
INSERT INTO `Report` VALUES (91,11,'2018-03-26','Grupa: --Dowolny pracownik--','Trasa testowa 2',2,'\0'),(92,12,'2018-03-26','Grupa: Grupa 1','Trasa testowa 2',3,'\0');
/*!40000 ALTER TABLE `Report` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ReportEmployee`
--

DROP TABLE IF EXISTS `ReportEmployee`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ReportEmployee` (
  `reportId` bigint(20) NOT NULL,
  `employeeId` varchar(31) NOT NULL,
  `employeeName` varchar(127) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`reportId`,`employeeId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ReportEmployee`
--

LOCK TABLES `ReportEmployee` WRITE;
/*!40000 ALTER TABLE `ReportEmployee` DISABLE KEYS */;
INSERT INTO `ReportEmployee` VALUES (91,'0',''),(92,'EFA62D','Jakub Dominikanin'),(92,'EFD576','Stanisław Nowak2'),(92,'F0D8B4','Piotr Kowalski');
/*!40000 ALTER TABLE `ReportEmployee` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ReportPlace`
--

DROP TABLE IF EXISTS `ReportPlace`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ReportPlace` (
  `reportId` bigint(20) NOT NULL,
  `placeName` varchar(255) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `status` varchar(127) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `markDescription` varchar(127) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `comment` varchar(511) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `department` varchar(127) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `visitDate` datetime NOT NULL,
  `markCommentRequired` bit(1) NOT NULL,
  PRIMARY KEY (`reportId`,`placeName`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ReportPlace`
--

LOCK TABLES `ReportPlace` WRITE;
/*!40000 ALTER TABLE `ReportPlace` DISABLE KEYS */;
INSERT INTO `ReportPlace` VALUES (91,'Agregat Diesla','Nieodwiedzono','','','Walcownia','0001-01-01 00:00:00','\0'),(91,'Lodówka','Nieodwiedzono','','','Biuro','0001-01-01 00:00:00','\0'),(92,'Agregat Diesla','Nieodwiedzono','','','Walcownia','0001-01-01 00:00:00','\0'),(92,'Lodówka','Nieodwiedzono','','','Biuro','0001-01-01 00:00:00','\0');
/*!40000 ALTER TABLE `ReportPlace` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Routine`
--

DROP TABLE IF EXISTS `Routine`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Routine` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `trackId` int(11) NOT NULL,
  `teamId` int(11) NOT NULL,
  `startDay` date NOT NULL,
  `cycleLength` int(11) NOT NULL,
  `cycleMask` bigint(20) NOT NULL,
  `shift` int(11) NOT NULL,
  `name` varchar(127) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Routine`
--

LOCK TABLES `Routine` WRITE;
/*!40000 ALTER TABLE `Routine` DISABLE KEYS */;
INSERT INTO `Routine` VALUES (10,6,0,'2018-03-21',4,5,1,'Rutyna nr 10'),(11,6,0,'2018-03-21',4,11,2,''),(12,6,2,'2018-03-17',4,11,3,''),(15,2,3,'2018-03-26',4,6,0,'');
/*!40000 ALTER TABLE `Routine` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Team`
--

DROP TABLE IF EXISTS `Team`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Team` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(127) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Team`
--

LOCK TABLES `Team` WRITE;
/*!40000 ALTER TABLE `Team` DISABLE KEYS */;
INSERT INTO `Team` VALUES (2,'Grupa 1'),(3,'Grupa 2');
/*!40000 ALTER TABLE `Team` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `TeamEmployee`
--

DROP TABLE IF EXISTS `TeamEmployee`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `TeamEmployee` (
  `teamId` int(11) NOT NULL,
  `employeeId` varchar(31) NOT NULL,
  PRIMARY KEY (`teamId`,`employeeId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `TeamEmployee`
--

LOCK TABLES `TeamEmployee` WRITE;
/*!40000 ALTER TABLE `TeamEmployee` DISABLE KEYS */;
INSERT INTO `TeamEmployee` VALUES (2,'EFA62D'),(2,'EFD576'),(2,'F0D8B4'),(3,'EFA62D'),(3,'F0D8B4');
/*!40000 ALTER TABLE `TeamEmployee` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Track`
--

DROP TABLE IF EXISTS `Track`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Track` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `creationDate` date NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Track`
--

LOCK TABLES `Track` WRITE;
/*!40000 ALTER TABLE `Track` DISABLE KEYS */;
INSERT INTO `Track` VALUES (2,'NowaxD','2018-03-18'),(5,'Trasa testowa','2018-03-19'),(6,'Trasa testowa 2','2018-03-19'),(14,'Nowa23','2018-03-18'),(15,'15','2018-03-18'),(16,'Nowa566655','2018-03-18'),(17,'NowaTest','2018-03-18');
/*!40000 ALTER TABLE `Track` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `TrackPlace`
--

DROP TABLE IF EXISTS `TrackPlace`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `TrackPlace` (
  `trackId` int(11) NOT NULL,
  `placeId` varchar(31) NOT NULL,
  PRIMARY KEY (`trackId`,`placeId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `TrackPlace`
--

LOCK TABLES `TrackPlace` WRITE;
/*!40000 ALTER TABLE `TrackPlace` DISABLE KEYS */;
INSERT INTO `TrackPlace` VALUES (2,'F06516'),(2,'F0DFC9'),(5,'F06516'),(6,'F0DFC9'),(6,'F0E0EE'),(15,'213213'),(16,'F06516'),(16,'F0E0EE'),(17,'F06516');
/*!40000 ALTER TABLE `TrackPlace` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-03-26 12:37:35
