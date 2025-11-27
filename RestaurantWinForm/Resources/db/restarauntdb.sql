-- MySQL dump 10.13  Distrib 8.0.44, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: restaurantdb
-- ------------------------------------------------------
-- Server version	8.0.44

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `menuitems`
--

DROP TABLE IF EXISTS `menuitems`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `menuitems` (
  `MenuItemId` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `Description` varchar(500) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `Price` decimal(10,2) NOT NULL,
  `IsActive` tinyint(1) DEFAULT '1',
  `CreatedDate` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`MenuItemId`),
  KEY `IX_MenuItems_IsActive` (`IsActive`),
  CONSTRAINT `menuitems_chk_1` CHECK ((`Price` > 0))
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `menuitems`
--

LOCK TABLES `menuitems` WRITE;
/*!40000 ALTER TABLE `menuitems` DISABLE KEYS */;
INSERT INTO `menuitems` VALUES (1,'Пицца крутая','Вы станете толстым если купите эту пиццу',800.00,1,'2025-11-27 17:00:37'),(2,'Пицца здоровая','Вы НЕ станете толстым если купите эту пиццу',900.00,1,'2025-11-27 17:00:37'),(3,'блюдо','Это новое блюдо',500.00,1,'2025-11-27 18:06:23');
/*!40000 ALTER TABLE `menuitems` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `orderdetails`
--

DROP TABLE IF EXISTS `orderdetails`;
/*!50001 DROP VIEW IF EXISTS `orderdetails`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `orderdetails` AS SELECT 
 1 AS `OrderId`,
 1 AS `SeatId`,
 1 AS `TotalPrice`,
 1 AS `StatusName`,
 1 AS `CreatedDate`,
 1 AS `UpdatedDate`,
 1 AS `ItemCount`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `orderitems`
--

DROP TABLE IF EXISTS `orderitems`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `orderitems` (
  `OrderItemId` int NOT NULL AUTO_INCREMENT,
  `OrderId` int NOT NULL,
  `MenuItemId` int NOT NULL,
  `Quantity` int NOT NULL,
  `Price` decimal(10,2) NOT NULL,
  PRIMARY KEY (`OrderItemId`),
  KEY `IX_OrderItems_OrderId` (`OrderId`),
  KEY `IX_OrderItems_MenuItemId` (`MenuItemId`),
  CONSTRAINT `orderitems_ibfk_1` FOREIGN KEY (`OrderId`) REFERENCES `orders` (`OrderId`) ON DELETE CASCADE,
  CONSTRAINT `orderitems_ibfk_2` FOREIGN KEY (`MenuItemId`) REFERENCES `menuitems` (`MenuItemId`),
  CONSTRAINT `orderitems_chk_1` CHECK ((`Quantity` > 0)),
  CONSTRAINT `orderitems_chk_2` CHECK ((`Price` > 0))
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orderitems`
--

LOCK TABLES `orderitems` WRITE;
/*!40000 ALTER TABLE `orderitems` DISABLE KEYS */;
INSERT INTO `orderitems` VALUES (1,1,1,2,800.00);
/*!40000 ALTER TABLE `orderitems` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `orderitemsdetails`
--

DROP TABLE IF EXISTS `orderitemsdetails`;
/*!50001 DROP VIEW IF EXISTS `orderitemsdetails`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `orderitemsdetails` AS SELECT 
 1 AS `OrderItemId`,
 1 AS `OrderId`,
 1 AS `MenuItemId`,
 1 AS `ItemName`,
 1 AS `Description`,
 1 AS `Quantity`,
 1 AS `Price`,
 1 AS `TotalPrice`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `orders`
--

DROP TABLE IF EXISTS `orders`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `orders` (
  `OrderId` int NOT NULL AUTO_INCREMENT,
  `SeatId` int NOT NULL,
  `TotalPrice` decimal(10,2) NOT NULL DEFAULT '0.00',
  `StatusId` int NOT NULL,
  `CreatedDate` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `UpdatedDate` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`OrderId`),
  KEY `IX_Orders_SeatId` (`SeatId`),
  KEY `IX_Orders_StatusId` (`StatusId`),
  CONSTRAINT `orders_ibfk_1` FOREIGN KEY (`StatusId`) REFERENCES `orderstatuses` (`StatusId`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orders`
--

LOCK TABLES `orders` WRITE;
/*!40000 ALTER TABLE `orders` DISABLE KEYS */;
INSERT INTO `orders` VALUES (1,1,1600.00,1,'2025-11-27 18:46:39','2025-11-27 18:46:39');
/*!40000 ALTER TABLE `orders` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orderstatuses`
--

DROP TABLE IF EXISTS `orderstatuses`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `orderstatuses` (
  `StatusId` int NOT NULL AUTO_INCREMENT,
  `StatusName` varchar(20) COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`StatusId`),
  UNIQUE KEY `StatusName` (`StatusName`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orderstatuses`
--

LOCK TABLES `orderstatuses` WRITE;
/*!40000 ALTER TABLE `orderstatuses` DISABLE KEYS */;
INSERT INTO `orderstatuses` VALUES (1,'Accepted'),(2,'Cooking'),(3,'Ready');
/*!40000 ALTER TABLE `orderstatuses` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orderstatuslog`
--

DROP TABLE IF EXISTS `orderstatuslog`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `orderstatuslog` (
  `LogId` int NOT NULL AUTO_INCREMENT,
  `OrderId` int NOT NULL,
  `OldStatusId` int DEFAULT NULL,
  `NewStatusId` int DEFAULT NULL,
  `ChangedDate` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `ChangedBy` int DEFAULT NULL,
  PRIMARY KEY (`LogId`),
  KEY `OrderId` (`OrderId`),
  KEY `OldStatusId` (`OldStatusId`),
  KEY `NewStatusId` (`NewStatusId`),
  CONSTRAINT `orderstatuslog_ibfk_1` FOREIGN KEY (`OrderId`) REFERENCES `orders` (`OrderId`),
  CONSTRAINT `orderstatuslog_ibfk_2` FOREIGN KEY (`OldStatusId`) REFERENCES `orderstatuses` (`StatusId`),
  CONSTRAINT `orderstatuslog_ibfk_3` FOREIGN KEY (`NewStatusId`) REFERENCES `orderstatuses` (`StatusId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orderstatuslog`
--

LOCK TABLES `orderstatuslog` WRITE;
/*!40000 ALTER TABLE `orderstatuslog` DISABLE KEYS */;
/*!40000 ALTER TABLE `orderstatuslog` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `staff`
--

DROP TABLE IF EXISTS `staff`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `staff` (
  `StaffId` int NOT NULL AUTO_INCREMENT,
  `UserName` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `Login` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `Password` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `RoleId` int NOT NULL,
  `CreatedDate` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`StaffId`),
  UNIQUE KEY `Login` (`Login`),
  KEY `RoleId` (`RoleId`),
  KEY `IX_Staff_Login` (`Login`),
  CONSTRAINT `staff_ibfk_1` FOREIGN KEY (`RoleId`) REFERENCES `userroles` (`RoleId`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `staff`
--

LOCK TABLES `staff` WRITE;
/*!40000 ALTER TABLE `staff` DISABLE KEYS */;
INSERT INTO `staff` VALUES (1,'Администратор','admin','admin123',3,'2025-11-27 17:00:37'),(2,'user1','login1','123',1,'2025-11-27 17:17:38'),(3,'user2','login2','1234',2,'2025-11-27 17:17:38'),(4,'waiter','newWaiter','123',1,'2025-11-27 17:33:23');
/*!40000 ALTER TABLE `staff` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `userroles`
--

DROP TABLE IF EXISTS `userroles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `userroles` (
  `RoleId` int NOT NULL AUTO_INCREMENT,
  `RoleName` varchar(20) COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`RoleId`),
  UNIQUE KEY `RoleName` (`RoleName`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `userroles`
--

LOCK TABLES `userroles` WRITE;
/*!40000 ALTER TABLE `userroles` DISABLE KEYS */;
INSERT INTO `userroles` VALUES (3,'Admin'),(2,'Cook'),(1,'Waiter');
/*!40000 ALTER TABLE `userroles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Final view structure for view `orderdetails`
--

/*!50001 DROP VIEW IF EXISTS `orderdetails`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `orderdetails` AS select `o`.`OrderId` AS `OrderId`,`o`.`SeatId` AS `SeatId`,`o`.`TotalPrice` AS `TotalPrice`,`os`.`StatusName` AS `StatusName`,`o`.`CreatedDate` AS `CreatedDate`,`o`.`UpdatedDate` AS `UpdatedDate`,count(`oi`.`OrderItemId`) AS `ItemCount` from ((`orders` `o` join `orderstatuses` `os` on((`o`.`StatusId` = `os`.`StatusId`))) left join `orderitems` `oi` on((`o`.`OrderId` = `oi`.`OrderId`))) group by `o`.`OrderId`,`o`.`SeatId`,`o`.`TotalPrice`,`os`.`StatusName`,`o`.`CreatedDate`,`o`.`UpdatedDate` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `orderitemsdetails`
--

/*!50001 DROP VIEW IF EXISTS `orderitemsdetails`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `orderitemsdetails` AS select `oi`.`OrderItemId` AS `OrderItemId`,`oi`.`OrderId` AS `OrderId`,`oi`.`MenuItemId` AS `MenuItemId`,`mi`.`Name` AS `ItemName`,`mi`.`Description` AS `Description`,`oi`.`Quantity` AS `Quantity`,`oi`.`Price` AS `Price`,(`oi`.`Quantity` * `oi`.`Price`) AS `TotalPrice` from (`orderitems` `oi` join `menuitems` `mi` on((`oi`.`MenuItemId` = `mi`.`MenuItemId`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-11-27 22:09:30
