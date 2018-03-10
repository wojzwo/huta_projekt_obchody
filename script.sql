-- MySQL dump 10.16  Distrib 10.1.26-MariaDB, for debian-linux-gnu (x86_64)
--
-- Host: localhost    Database: hutadb
-- ------------------------------------------------------
-- Server version	10.1.26-MariaDB-0+deb9u1

USE hutadb;

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
-- Table structure for table `Chip`
--

DROP TABLE IF EXISTS `Chip`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Chip` (
  `chipId` varchar(64) NOT NULL,
  `isEmployee` bit(1) DEFAULT NULL,
  PRIMARY KEY (`chipId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Chip`
--

LOCK TABLES `Chip` WRITE;
/*!40000 ALTER TABLE `Chip` DISABLE KEYS */;
INSERT INTO `Chip` VALUES ('EFA62D',''),('EFD576',''),('F06516','\0'),('F0D8B4',''),('F0DFC9','\0'),('F0E0EE','\0');
/*!40000 ALTER TABLE `Chip` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Employee`
--

DROP TABLE IF EXISTS `Employee`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Employee` (
  `chipId` varchar(64) NOT NULL,
  `name` varchar(128) CHARACTER SET utf8 COLLATE utf8_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`chipId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Employee`
--

LOCK TABLES `Employee` WRITE;
/*!40000 ALTER TABLE `Employee` DISABLE KEYS */;
INSERT INTO `Employee` VALUES ('EFA62D','Jakub Dominikanin'),('EFD576','Stanislaw Nowak'),('F0D8B4','Piotr Kowalski');
/*!40000 ALTER TABLE `Employee` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Mark`
--

DROP TABLE IF EXISTS `Mark`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Mark` (
  `id` int(11) NOT NULL,
  `name` varchar(128) CHARACTER SET utf8 COLLATE utf8_unicode_ci DEFAULT NULL,
  `isCommentRequired` bit(1) DEFAULT NULL,
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
  `chipId` varchar(64) NOT NULL,
  `name` varchar(256) CHARACTER SET utf8 COLLATE utf8_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`chipId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Place`
--

LOCK TABLES `Place` WRITE;
/*!40000 ALTER TABLE `Place` DISABLE KEYS */;
INSERT INTO `Place` VALUES ('F06516','Odlewnia'),('F0DFC9','Biuro'),('F0E0EE','Walcownia');
/*!40000 ALTER TABLE `Place` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Report`
--

DROP TABLE IF EXISTS `Report`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Report` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `trackId` int(11) DEFAULT NULL,
  `employeeId` varchar(64) DEFAULT NULL,
  `dueDate` date DEFAULT NULL,
  `isFinished` bit(1) DEFAULT NULL,
  `isRepeating` bit(1) DEFAULT NULL,
  `isEmployeeAdded` bit(1) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Report`
--

LOCK TABLES `Report` WRITE;
/*!40000 ALTER TABLE `Report` DISABLE KEYS */;
/*!40000 ALTER TABLE `Report` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ReportPlace`
--

DROP TABLE IF EXISTS `ReportPlace`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ReportPlace` (
  `reportId` int(11) DEFAULT NULL,
  `placeId` int(11) DEFAULT NULL,
  `status` varchar(64) DEFAULT NULL,
  `mark` int(11) DEFAULT NULL,
  `comment` varchar(256) DEFAULT NULL,
  `visitDate` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ReportPlace`
--

LOCK TABLES `ReportPlace` WRITE;
/*!40000 ALTER TABLE `ReportPlace` DISABLE KEYS */;
/*!40000 ALTER TABLE `ReportPlace` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Track`
--

DROP TABLE IF EXISTS `Track`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Track` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(256) CHARACTER SET utf8 COLLATE utf8_unicode_ci DEFAULT NULL,
  `creationDate` date DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Track`
--

LOCK TABLES `Track` WRITE;
/*!40000 ALTER TABLE `Track` DISABLE KEYS */;
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
  `placeId` int(11) NOT NULL,
  PRIMARY KEY (`trackId`,`placeId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `TrackPlace`
--

LOCK TABLES `TrackPlace` WRITE;
/*!40000 ALTER TABLE `TrackPlace` DISABLE KEYS */;
/*!40000 ALTER TABLE `TrackPlace` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `TrackRepeating`
--

DROP TABLE IF EXISTS `TrackRepeating`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `TrackRepeating` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `trackId` int(11) DEFAULT NULL,
  `employeeId` varchar(64) DEFAULT NULL,
  `dayStart` date DEFAULT NULL,
  `repeatLength` int(11) DEFAULT NULL,
  `repeatMask` bigint DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `TrackRepeating`
--

LOCK TABLES `TrackRepeating` WRITE;
/*!40000 ALTER TABLE `TrackRepeating` DISABLE KEYS */;
/*!40000 ALTER TABLE `TrackRepeating` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-03-10 16:10:52
