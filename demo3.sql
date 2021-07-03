/*
 Navicat Premium Data Transfer

 Source Server         : localhost_3306
 Source Server Type    : MySQL
 Source Server Version : 50637
 Source Host           : localhost:3306
 Source Schema         : demo3

 Target Server Type    : MySQL
 Target Server Version : 50637
 File Encoding         : 65001

 Date: 03/07/2021 16:57:42
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for __efmigrationshistory
-- ----------------------------
DROP TABLE IF EXISTS `__efmigrationshistory`;
CREATE TABLE `__efmigrationshistory`  (
  `MigrationId` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `ProductVersion` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  PRIMARY KEY (`MigrationId`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = COMPACT;

-- ----------------------------
-- Records of __efmigrationshistory
-- ----------------------------

-- ----------------------------
-- Table structure for admin
-- ----------------------------
DROP TABLE IF EXISTS `admin`;
CREATE TABLE `admin`  (
  `AdminName` varchar(95) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `Password` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL,
  PRIMARY KEY (`AdminName`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = COMPACT;

-- ----------------------------
-- Records of admin
-- ----------------------------
INSERT INTO `admin` VALUES ('哈哈', '123');
INSERT INTO `admin` VALUES ('地方飒飒', '678');

-- ----------------------------
-- Table structure for comment
-- ----------------------------
DROP TABLE IF EXISTS `comment`;
CREATE TABLE `comment`  (
  `CommentId` int(11) NOT NULL AUTO_INCREMENT,
  `LikeNum` int(11) UNSIGNED ZEROFILL NOT NULL,
  `Detail` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL,
  `IsReported` tinyint(1) UNSIGNED ZEROFILL NOT NULL,
  `RelatedUserUserName` varchar(95) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `RelatedQuestionQuestionId` int(11) NULL DEFAULT NULL,
  `Reason` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL,
  PRIMARY KEY (`CommentId`) USING BTREE,
  INDEX `IX_COMMENT_RelatedQuestionQuestionId`(`RelatedQuestionQuestionId`) USING BTREE,
  INDEX `IX_COMMENT_RelatedUserUserName`(`RelatedUserUserName`) USING BTREE,
  CONSTRAINT `FK_COMMENT_QUESTION_RelatedQuestionQuestionId` FOREIGN KEY (`RelatedQuestionQuestionId`) REFERENCES `question` (`QuestionId`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_COMMENT_USER_RelatedUserUserName` FOREIGN KEY (`RelatedUserUserName`) REFERENCES `user` (`UserName`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 23 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = COMPACT;

-- ----------------------------
-- Records of comment
-- ----------------------------
INSERT INTO `comment` VALUES (1, 00000000004, '作业比较少', 0, 'yang帆', 1, NULL);
INSERT INTO `comment` VALUES (2, 00000000016, '作业不多', 0, 'azyrg88422', 1, '');
INSERT INTO `comment` VALUES (3, 00000000008, '论文结课，不少于3000字', 0, '啊哈哈', 2, '');
INSERT INTO `comment` VALUES (4, 00000000002, '作业比较少', 0, 'whuanle', 7, NULL);
INSERT INTO `comment` VALUES (5, 00000000010, '作业不多', 0, 'azyrg88422', 7, NULL);
INSERT INTO `comment` VALUES (6, 00000000001, '论文结课，不少于3000字', 0, '啊哈哈', 8, NULL);
INSERT INTO `comment` VALUES (7, 00000000001, '作业比较少', 0, '啊哈哈', 13, NULL);
INSERT INTO `comment` VALUES (8, 00000000018, '作业不多', 0, 'azyrg88422', 13, NULL);
INSERT INTO `comment` VALUES (9, 00000000034, '论文结课，不少于3000字', 0, 'yang帆', 14, NULL);
INSERT INTO `comment` VALUES (10, 00000000001, '作业贼多', 0, '啊哈哈', 1, NULL);
INSERT INTO `comment` VALUES (21, 00000000000, '讲课效果很好', 0, '222', 17, NULL);
INSERT INTO `comment` VALUES (22, 00000000001, '不多', 0, 'a哈哈', 55, NULL);

-- ----------------------------
-- Table structure for course
-- ----------------------------
DROP TABLE IF EXISTS `course`;
CREATE TABLE `course`  (
  `CourseId` varchar(95) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL,
  `Type` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL,
  `TeacherName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL,
  `Department` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL,
  `BookName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL,
  `Introduction` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL,
  `HeatNum` int(11) UNSIGNED ZEROFILL NULL DEFAULT NULL,
  `LikeNum` int(11) UNSIGNED ZEROFILL NULL DEFAULT NULL,
  PRIMARY KEY (`CourseId`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = COMPACT;

-- ----------------------------
-- Records of course
-- ----------------------------
INSERT INTO `course` VALUES ('20191022009', '程序设计基础', '专业教育必修', '邓德祥', NULL, '无', '暂无', 00000000000, 00000000000);
INSERT INTO `course` VALUES ('20191056032', '高等数学B1', '公共基础必修', '黄学英', NULL, '无', '暂无', 00000000000, 00000000000);
INSERT INTO `course` VALUES ('20191106336', '人文社科经典导引', '通识教育必修', '刘伟', NULL, '无', '暂无', 00000000000, 00000000000);
INSERT INTO `course` VALUES ('20192022674', '算法与数据结构', '专业教育选修', '刘勇', NULL, '无', '暂无', 00000000000, 00000000000);
INSERT INTO `course` VALUES ('20201021112', '计算机组成与设计', '专业教育必修', '李宗福', '计算机学院', '计算机组成与设计 机械工业出版', '课程简介:《计算机组成与系统结构》是计算机学科领域内各类专业的必修课，本次授课对象为大二计算机科学与技术专业的学生。课程主要介绍单机系统各部件组成原理、系统结构及工作机制，主要内容包括:数据的表示，计算机硬件设计基础，计算机五个功能部件的组成原理、逻辑实现及设计技术，指令系统理论，总线系统理论，流水线技术等。通过课程学习，建立起计算机系统的完整概念，将计算机软、硬件知识有机地结合起来，为学生对计算机系统的分析、设计、开发和使用能力打下基础。', 00000000104, 00000000012);
INSERT INTO `course` VALUES ('20201040395', '排球（初级）', '公共基础必修', '黄武', NULL, '无', '暂无', 00000000000, 00000000000);
INSERT INTO `course` VALUES ('20201083586', '大学生心理健康', '通识教育选修', '曾翘楚', NULL, '无', '暂无', 00000000856, 00000000005);
INSERT INTO `course` VALUES ('20202021762', '计算机网络', '专业教育必修', '王继承', '计算机学院', '计算机网络谢希仁版', '计算机网络是计算机和数据通信结合的学科。是计算机科学、信息科学专业的专业主干课程。本课程主要讲授网络通信和协议实现，以现阶段主流协议TCP/IP为主线，对五个功能层进行详细地描述。内容涵盖网络概述、物理层、数据链路层、LAN、WAN、网络互连、运输层（传输层）、应用层、计算机网络安全、Internet的演进等。本课程所选择的教材接近国际著名教材，内容先进且实用，知识面涵盖较广。', 00000000519, 00000000012);
INSERT INTO `course` VALUES ('20202021766', '操作系统', '专业教育必修', '蒋晶钰', '计算机学院', '计算机操作系统(第二版)', '本课程主要介绍了操作系统的概论、进程管理、调度与死锁、存储器管理、设备管理、文件管理、操作系统安全与保护等内容。通过本课程的学习，要求掌握操作系统的基本原理及组成构架，理解进程控制的基本原理及方法，理解处理机调度和死锁基本原理和方法，理解存储器和虚拟存储器管理的基本原理和方法，了解I/O系统和文件系统的基本原理和方法，了解操作系统的安全需求和访问控制策略，能够简单运用计算机操作系统的基本思想及方法发现问题、分析问题、解决问题。', 00000000000, 00000000005);
INSERT INTO `course` VALUES ('20202021779', '软件构造基础', '专业教育选修', '贾向阳', '计算机学院', 'C#程序设计教程', '本课程是计算机软件专业的一门重要的编程类专业课。C#语言是针对网络技术应用而开发的语言，课程的教学目的是培养学生使用NET平台开发网络应用程序的能力，主要教学内容以应用为主，以语法介绍为辅，主要包括C#语言基本语法、面向对象编程方、C#开发Windows应用程序、C#开发Web应用程序等。', 00000000551, 00000000016);
INSERT INTO `course` VALUES ('20202021784', '移动编程技术', '专业教育选修', '高建华', NULL, '无', 'iOS开发', 00000000013, 00000000005);
INSERT INTO `course` VALUES ('20202057459', '大学物理D1', '公共基础必修', '尹玲', '公共物理教学', '大学物理学沈黄晋版', '课程内容：力学(质点运动学质点动力学刚体定轴转动流体力学简介狭义相对论力学简介)、电磁学（静电场稳恒磁场电、磁场与实物的相互作用电磁感应麦克斯韦方程组)\r\n成绩评定：期中考试15%+平时作业15%+考勤10%+期末卷面60%\r\n作业：每章交一次，主要由研究生助教批改并登记\r\n参考书：《大学物理学学习指导》 沈黄晋 主编 高等教育出版社 2018 \r\n《大学物理学习题解答》（电子书） 沈黄晋 主编 高等教育出版社 2017\r\n《新编基础物理学》（第二版）科学出版社 王少杰 顾牡主编 2014 年\r\n《物理学》（第 6 版） 马文蔚改编 高等教育出版社\r\n《普通物理学》（第 6 版） 程守珠 江之用主编 高等教育出版社 \r\n', 00000000000, 00000000004);
INSERT INTO `course` VALUES ('20203062826', '俄罗斯历史', '通识教育选修', '牟沐英', '中国边界与海洋研究院', '无', '俄罗斯历史是一门介绍、研究俄罗斯国家的自然地理、历史人文、政治经济、文化、民俗、教育等内容的学科。本课程旨在通过对俄罗斯上述各个方面的学习和研究，熟悉、掌握相关内容，提高学生对文化差异的敏感性、宽容性和处理文化差异的灵活性，培养学生跨文化交际能力，为以后进一步了解俄罗斯、俄语打下基础。', 00000000000, 00000000001);

-- ----------------------------
-- Table structure for course_user_score
-- ----------------------------
DROP TABLE IF EXISTS `course_user_score`;
CREATE TABLE `course_user_score`  (
  `CUSId` int(11) NOT NULL AUTO_INCREMENT,
  `UserName` varchar(95) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `CourseId` varchar(95) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `Score` int(11) NOT NULL,
  PRIMARY KEY (`CUSId`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 29 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = COMPACT;

-- ----------------------------
-- Records of course_user_score
-- ----------------------------
INSERT INTO `course_user_score` VALUES (1, 'azyrg88422', '20202021762', 4);
INSERT INTO `course_user_score` VALUES (8, 'whuanle', '20202057459', 1);
INSERT INTO `course_user_score` VALUES (14, 'whuanle', '20202021779', 5);
INSERT INTO `course_user_score` VALUES (15, 'whuanle', '20201021112', 2);
INSERT INTO `course_user_score` VALUES (16, 'whuanle', '20203062826', 3);
INSERT INTO `course_user_score` VALUES (17, 'whuanle', '20202021766', 1);
INSERT INTO `course_user_score` VALUES (18, '啊哈哈', '20202021766', 4);
INSERT INTO `course_user_score` VALUES (19, '啊哈哈', '20202057459', 2);
INSERT INTO `course_user_score` VALUES (20, '啊哈哈', '20202021779', 4);
INSERT INTO `course_user_score` VALUES (21, '啊哈哈', '20201021112', 5);
INSERT INTO `course_user_score` VALUES (22, '2333', '20201083586', 5);
INSERT INTO `course_user_score` VALUES (23, '啊哈哈', '20201083586', 4);
INSERT INTO `course_user_score` VALUES (24, '444', '20202021779', 5);
INSERT INTO `course_user_score` VALUES (25, '555', '20202021779', 5);
INSERT INTO `course_user_score` VALUES (26, '555', '20202021766', 5);
INSERT INTO `course_user_score` VALUES (27, '222', '20202021779', 5);
INSERT INTO `course_user_score` VALUES (28, 'a哈哈', '20201083586', 3);

-- ----------------------------
-- Table structure for courseuser
-- ----------------------------
DROP TABLE IF EXISTS `courseuser`;
CREATE TABLE `courseuser`  (
  `LikeCoursesCourseId` varchar(95) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `UserWhoLikedCourseUserName` varchar(95) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  PRIMARY KEY (`LikeCoursesCourseId`, `UserWhoLikedCourseUserName`) USING BTREE,
  INDEX `IX_CourseUser_UserWhoLikedCourseUserName`(`UserWhoLikedCourseUserName`) USING BTREE,
  CONSTRAINT `FK_CourseUser_COURSE_LikeCoursesCourseId` FOREIGN KEY (`LikeCoursesCourseId`) REFERENCES `course` (`CourseId`) ON DELETE CASCADE ON UPDATE RESTRICT,
  CONSTRAINT `FK_CourseUser_USER_UserWhoLikedCourseUserName` FOREIGN KEY (`UserWhoLikedCourseUserName`) REFERENCES `user` (`UserName`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = COMPACT;

-- ----------------------------
-- Records of courseuser
-- ----------------------------
INSERT INTO `courseuser` VALUES ('20201021112', '111');
INSERT INTO `courseuser` VALUES ('20202021762', '111');
INSERT INTO `courseuser` VALUES ('20202021779', '111');
INSERT INTO `courseuser` VALUES ('20202021784', '111');
INSERT INTO `courseuser` VALUES ('20201021112', '222');
INSERT INTO `courseuser` VALUES ('20202021762', '222');
INSERT INTO `courseuser` VALUES ('20202021779', '222');
INSERT INTO `courseuser` VALUES ('20202021784', '222');
INSERT INTO `courseuser` VALUES ('20201021112', '333');
INSERT INTO `courseuser` VALUES ('20202021762', '333');
INSERT INTO `courseuser` VALUES ('20201021112', 'azyrg88422');
INSERT INTO `courseuser` VALUES ('20202021762', 'azyrg88422');
INSERT INTO `courseuser` VALUES ('20202021766', 'azyrg88422');
INSERT INTO `courseuser` VALUES ('20202021779', 'azyrg88422');
INSERT INTO `courseuser` VALUES ('20202057459', 'azyrg88422');
INSERT INTO `courseuser` VALUES ('20202021779', 'a哈哈');
INSERT INTO `courseuser` VALUES ('20202021784', 'a哈哈');
INSERT INTO `courseuser` VALUES ('20202021762', 'whuanle');
INSERT INTO `courseuser` VALUES ('20202021766', 'whuanle');
INSERT INTO `courseuser` VALUES ('20202021779', 'whuanle');
INSERT INTO `courseuser` VALUES ('20202057459', 'whuanle');
INSERT INTO `courseuser` VALUES ('20203062826', 'whuanle');
INSERT INTO `courseuser` VALUES ('20202021762', 'yang帆');
INSERT INTO `courseuser` VALUES ('20202021766', 'yang帆');
INSERT INTO `courseuser` VALUES ('20202057459', 'yang帆');
INSERT INTO `courseuser` VALUES ('20201083586', '啊哈哈');

-- ----------------------------
-- Table structure for question
-- ----------------------------
DROP TABLE IF EXISTS `question`;
CREATE TABLE `question`  (
  `QuestionId` int(11) NOT NULL AUTO_INCREMENT,
  `LikeNum` int(11) UNSIGNED ZEROFILL NOT NULL,
  `Detail` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL,
  `IsReported` tinyint(1) UNSIGNED ZEROFILL NOT NULL,
  `Reason` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL,
  `RelatedCourseCourseId` varchar(95) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `RelatedUserUserName` varchar(95) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`QuestionId`) USING BTREE,
  INDEX `IX_QUESTION_RelatedCourseCourseId`(`RelatedCourseCourseId`) USING BTREE,
  INDEX `IX_QUESTION_RelatedUserUserName`(`RelatedUserUserName`) USING BTREE,
  CONSTRAINT `FK_QUESTION_COURSE_RelatedCourseCourseId` FOREIGN KEY (`RelatedCourseCourseId`) REFERENCES `course` (`CourseId`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_QUESTION_USER_RelatedUserUserName` FOREIGN KEY (`RelatedUserUserName`) REFERENCES `user` (`UserName`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 114 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = COMPACT;

-- ----------------------------
-- Records of question
-- ----------------------------
INSERT INTO `question` VALUES (1, 00000000001, '这门课平时作业多吗？', 0, NULL, '20202021762', 'admin');
INSERT INTO `question` VALUES (2, 00000000046, '这门课的结课方式是怎么样的？', 0, NULL, '20202021762', 'admin');
INSERT INTO `question` VALUES (3, 00000000034, '老师期末给分怎么样？', 0, NULL, '20202021762', 'admin');
INSERT INTO `question` VALUES (4, 00000000021, '平时上课签到多吗，老师点名吗？', 0, NULL, '20202021762', 'admin');
INSERT INTO `question` VALUES (5, 00000000013, '老师讲课效果怎么样？', 0, NULL, '20202021762', 'admin');
INSERT INTO `question` VALUES (6, 00000000027, '这门课难度大吗，需要什么先修课程，不会听不懂吧?', 0, NULL, '20202021762', 'admin');
INSERT INTO `question` VALUES (7, 00000000007, '这门课平时作业多吗？', 0, '', '20202021766', 'admin');
INSERT INTO `question` VALUES (8, 00000000007, '这门课的结课方式是怎么样的？', 0, NULL, '20202021766', 'admin');
INSERT INTO `question` VALUES (9, 00000000003, '老师期末给分怎么样？', 0, NULL, '20202021766', 'admin');
INSERT INTO `question` VALUES (10, 00000000002, '平时上课签到多吗，老师点名吗？', 0, NULL, '20202021766', 'admin');
INSERT INTO `question` VALUES (11, 00000000000, '老师讲课效果怎么样？', 0, NULL, '20202021766', 'admin');
INSERT INTO `question` VALUES (12, 00000000000, '这门课难度大吗，需要什么先修课程，不会听不懂吧?', 0, NULL, '20202021766', 'admin');
INSERT INTO `question` VALUES (13, 00000000002, '这门课平时作业多吗？', 0, NULL, '20202021779', 'admin');
INSERT INTO `question` VALUES (14, 00000000002, '这门课的结课方式是怎么样的？', 0, NULL, '20202021779', 'admin');
INSERT INTO `question` VALUES (15, 00000000004, '老师期末给分怎么样？', 0, NULL, '20202021779', 'admin');
INSERT INTO `question` VALUES (16, 00000000001, '平时上课签到多吗，老师点名吗？', 0, NULL, '20202021779', 'admin');
INSERT INTO `question` VALUES (17, 00000000001, '老师讲课效果怎么样？', 0, NULL, '20202021779', 'admin');
INSERT INTO `question` VALUES (18, 00000000000, '这门课难度大吗，需要什么先修课程，不会听不懂吧?', 0, NULL, '20202021779', 'admin');
INSERT INTO `question` VALUES (19, 00000000000, '这门课平时作业多吗？', 0, NULL, '20202057459', 'admin');
INSERT INTO `question` VALUES (20, 00000000000, '这门课的结课方式是怎么样的？', 0, NULL, '20202057459', 'admin');
INSERT INTO `question` VALUES (21, 00000000000, '老师期末给分怎么样？', 0, NULL, '20202057459', 'admin');
INSERT INTO `question` VALUES (22, 00000000000, '平时上课签到多吗，老师点名吗？', 0, NULL, '20202057459', 'admin');
INSERT INTO `question` VALUES (23, 00000000000, '老师讲课效果怎么样？', 0, NULL, '20202057459', 'admin');
INSERT INTO `question` VALUES (24, 00000000000, '这门课难度大吗，需要什么先修课程，不会听不懂吧?', 0, NULL, '20202057459', 'admin');
INSERT INTO `question` VALUES (25, 00000000000, '这门课平时作业多吗？', 0, NULL, '20203062826', 'admin');
INSERT INTO `question` VALUES (26, 00000000001, '这门课的结课方式是怎么样的？', 0, NULL, '20203062826', 'admin');
INSERT INTO `question` VALUES (27, 00000000001, '老师期末给分怎么样？', 0, NULL, '20203062826', 'admin');
INSERT INTO `question` VALUES (28, 00000000001, '平时上课签到多吗，老师点名吗？', 0, NULL, '20203062826', 'admin');
INSERT INTO `question` VALUES (29, 00000000001, '老师讲课效果怎么样？', 0, NULL, '20203062826', 'admin');
INSERT INTO `question` VALUES (30, 00000000000, '这门课难度大吗，需要什么先修课程，不会听不懂吧?', 0, NULL, '20203062826', 'admin');
INSERT INTO `question` VALUES (31, 00000000000, '这门课平时作业多吗？', 0, NULL, '20201021112', 'admin');
INSERT INTO `question` VALUES (32, 00000000000, '这门课的结课方式是怎么样的？', 0, NULL, '20201021112', 'admin');
INSERT INTO `question` VALUES (33, 00000000000, '老师期末给分怎么样？', 0, NULL, '20201021112', 'admin');
INSERT INTO `question` VALUES (34, 00000000000, '平时上课签到多吗，老师点名吗？', 0, NULL, '20201021112', 'admin');
INSERT INTO `question` VALUES (35, 00000000000, '老师讲课效果怎么样？', 0, NULL, '20201021112', 'admin');
INSERT INTO `question` VALUES (36, 00000000000, '这门课难度大吗，需要什么先修课程，不会听不懂吧?', 0, NULL, '20201021112', 'admin');
INSERT INTO `question` VALUES (38, 00000000001, '老师上课形式是怎么样的？', 0, '', '20202021762', 'whuanle');
INSERT INTO `question` VALUES (39, 00000000000, '你好', 0, '迷惑发言', '20202021762', 'whuanle');
INSERT INTO `question` VALUES (40, 00000000000, '爱回收', 0, '无价值的问题', '20202021762', '啊哈哈');
INSERT INTO `question` VALUES (41, 00000000000, '怎嘛用', 0, NULL, '20202021779', '啊哈哈');
INSERT INTO `question` VALUES (42, 00000000000, '飒飒', 1, '啊飒飒的个', '20201021112', '啊哈哈');
INSERT INTO `question` VALUES (43, 00000000000, '这门课平时作业多吗？', 0, NULL, '20191106336', 'admin');
INSERT INTO `question` VALUES (44, 00000000000, '这门课的结课方式是怎么样的？', 0, NULL, '20191106336', 'admin');
INSERT INTO `question` VALUES (45, 00000000000, '老师期末给分怎么样？', 0, NULL, '20191106336', 'admin');
INSERT INTO `question` VALUES (46, 00000000000, '平时上课签到多吗，老师点名吗？', 0, NULL, '20191106336', 'admin');
INSERT INTO `question` VALUES (47, 00000000000, '老师讲课效果怎么样？', 0, NULL, '20191106336', 'admin');
INSERT INTO `question` VALUES (48, 00000000000, '这门课难度大吗，需要什么先修课程，不会听不懂吧?', 0, NULL, '20191106336', 'admin');
INSERT INTO `question` VALUES (49, 00000000000, '这门课平时作业多吗？', 0, NULL, '20191056032', 'admin');
INSERT INTO `question` VALUES (50, 00000000000, '这门课的结课方式是怎么样的？', 0, NULL, '20191056032', 'admin');
INSERT INTO `question` VALUES (51, 00000000000, '老师期末给分怎么样？', 0, NULL, '20191056032', 'admin');
INSERT INTO `question` VALUES (52, 00000000000, '平时上课签到多吗，老师点名吗？', 0, NULL, '20191056032', 'admin');
INSERT INTO `question` VALUES (53, 00000000000, '老师讲课效果怎么样？', 0, NULL, '20191056032', 'admin');
INSERT INTO `question` VALUES (54, 00000000000, '这门课难度大吗，需要什么先修课程，不会听不懂吧?', 0, NULL, '20191056032', 'admin');
INSERT INTO `question` VALUES (55, 00000000000, '这门课平时作业多吗？', 0, NULL, '20201083586', 'admin');
INSERT INTO `question` VALUES (56, 00000000004, '这门课的结课方式是怎么样的？', 0, NULL, '20201083586', 'admin');
INSERT INTO `question` VALUES (57, 00000000000, '老师期末给分怎么样？', 0, NULL, '20201083586', 'admin');
INSERT INTO `question` VALUES (58, 00000000004, '平时上课签到多吗，老师点名吗？', 0, NULL, '20201083586', 'admin');
INSERT INTO `question` VALUES (59, 00000000000, '老师讲课效果怎么样？', 0, NULL, '20201083586', 'admin');
INSERT INTO `question` VALUES (60, 00000000007, '这门课难度大吗，需要什么先修课程，不会听不懂吧?', 0, NULL, '20201083586', 'admin');
INSERT INTO `question` VALUES (61, 00000000000, '这门课平时作业多吗？', 0, NULL, '20191022009', 'admin');
INSERT INTO `question` VALUES (62, 00000000000, '这门课的结课方式是怎么样的？', 0, NULL, '20191022009', 'admin');
INSERT INTO `question` VALUES (63, 00000000000, '老师期末给分怎么样？', 0, NULL, '20191022009', 'admin');
INSERT INTO `question` VALUES (64, 00000000000, '平时上课签到多吗，老师点名吗？', 0, NULL, '20191022009', 'admin');
INSERT INTO `question` VALUES (65, 00000000000, '老师讲课效果怎么样？', 0, NULL, '20191022009', 'admin');
INSERT INTO `question` VALUES (66, 00000000000, '这门课难度大吗，需要什么先修课程，不会听不懂吧?', 0, NULL, '20191022009', 'admin');
INSERT INTO `question` VALUES (67, 00000000000, '这门课平时作业多吗？', 0, NULL, '20192022674', 'admin');
INSERT INTO `question` VALUES (68, 00000000000, '这门课的结课方式是怎么样的？', 0, NULL, '20192022674', 'admin');
INSERT INTO `question` VALUES (69, 00000000000, '老师期末给分怎么样？', 0, NULL, '20192022674', 'admin');
INSERT INTO `question` VALUES (70, 00000000000, '平时上课签到多吗，老师点名吗？', 0, NULL, '20192022674', 'admin');
INSERT INTO `question` VALUES (71, 00000000000, '老师讲课效果怎么样？', 0, NULL, '20192022674', 'admin');
INSERT INTO `question` VALUES (72, 00000000000, '这门课难度大吗，需要什么先修课程，不会听不懂吧?', 0, NULL, '20192022674', 'admin');
INSERT INTO `question` VALUES (73, 00000000000, '这门课平时作业多吗？', 0, NULL, '20201040395', 'admin');
INSERT INTO `question` VALUES (74, 00000000000, '这门课的结课方式是怎么样的？', 0, NULL, '20201040395', 'admin');
INSERT INTO `question` VALUES (75, 00000000000, '老师期末给分怎么样？', 0, NULL, '20201040395', 'admin');
INSERT INTO `question` VALUES (76, 00000000000, '平时上课签到多吗，老师点名吗？', 0, NULL, '20201040395', 'admin');
INSERT INTO `question` VALUES (77, 00000000000, '老师讲课效果怎么样？', 0, NULL, '20201040395', 'admin');
INSERT INTO `question` VALUES (78, 00000000000, '这门课难度大吗，需要什么先修课程，不会听不懂吧?', 0, NULL, '20201040395', 'admin');
INSERT INTO `question` VALUES (79, 00000000000, '这门课平时作业多吗？', 0, NULL, '20202021784', 'admin');
INSERT INTO `question` VALUES (80, 00000000000, '这门课的结课方式是怎么样的？', 0, NULL, '20202021784', 'admin');
INSERT INTO `question` VALUES (81, 00000000000, '老师期末给分怎么样？', 0, NULL, '20202021784', 'admin');
INSERT INTO `question` VALUES (82, 00000000000, '平时上课签到多吗，老师点名吗？', 0, NULL, '20202021784', 'admin');
INSERT INTO `question` VALUES (83, 00000000000, '老师讲课效果怎么样？', 0, NULL, '20202021784', 'admin');
INSERT INTO `question` VALUES (84, 00000000000, '这门课难度大吗，需要什么先修课程，不会听不懂吧?', 0, NULL, '20202021784', 'admin');
INSERT INTO `question` VALUES (85, 00000000007, '圣诞节阿卡', 0, NULL, '20201083586', '啊哈哈');
INSERT INTO `question` VALUES (113, 00000000000, '草', 0, NULL, '20201083586', 'a哈哈');

-- ----------------------------
-- Table structure for tag
-- ----------------------------
DROP TABLE IF EXISTS `tag`;
CREATE TABLE `tag`  (
  `TagId` int(11) NOT NULL AUTO_INCREMENT,
  `Detail` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL,
  `LikeNum` int(11) UNSIGNED ZEROFILL NOT NULL,
  `RelatedQuestionQuestionId` int(11) NULL DEFAULT NULL,
  PRIMARY KEY (`TagId`) USING BTREE,
  INDEX `IX_TAG_RelatedQuestionQuestionId`(`RelatedQuestionQuestionId`) USING BTREE,
  CONSTRAINT `FK_TAG_QUESTION_RelatedQuestionQuestionId` FOREIGN KEY (`RelatedQuestionQuestionId`) REFERENCES `question` (`QuestionId`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 18 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = COMPACT;

-- ----------------------------
-- Records of tag
-- ----------------------------
INSERT INTO `tag` VALUES (9, '讲课效果好', 00000000050, 17);
INSERT INTO `tag` VALUES (10, '给分很好', 00000000026, 15);
INSERT INTO `tag` VALUES (11, '大作业结课', 00000000033, 14);
INSERT INTO `tag` VALUES (12, '高分多', 00000000045, 15);
INSERT INTO `tag` VALUES (13, '平时作业少', 00000000012, 55);
INSERT INTO `tag` VALUES (14, '难度不大', 00000000014, 60);
INSERT INTO `tag` VALUES (15, '有点抽象', 00000000045, 6);
INSERT INTO `tag` VALUES (16, '给分不错', 00000000066, 3);
INSERT INTO `tag` VALUES (17, '作业不多', 00000000001, 55);

-- ----------------------------
-- Table structure for user
-- ----------------------------
DROP TABLE IF EXISTS `user`;
CREATE TABLE `user`  (
  `UserName` varchar(95) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `Password` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL,
  `Gender` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL,
  `Grade` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL,
  `Introduction` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL,
  `Major` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL,
  PRIMARY KEY (`UserName`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = COMPACT;

-- ----------------------------
-- Records of user
-- ----------------------------
INSERT INTO `user` VALUES ('111', '111', NULL, NULL, NULL, NULL);
INSERT INTO `user` VALUES ('222', '222', NULL, NULL, NULL, NULL);
INSERT INTO `user` VALUES ('2333', '123', NULL, NULL, NULL, NULL);
INSERT INTO `user` VALUES ('333', '333', NULL, NULL, NULL, NULL);
INSERT INTO `user` VALUES ('444', '444', NULL, NULL, NULL, NULL);
INSERT INTO `user` VALUES ('555', '555', NULL, NULL, NULL, NULL);
INSERT INTO `user` VALUES ('admin', '36736721', NULL, NULL, NULL, NULL);
INSERT INTO `user` VALUES ('azyrg88422', '1267332', '男', '2018', NULL, NULL);
INSERT INTO `user` VALUES ('a哈哈', '1234', '男', '2019', '', '');
INSERT INTO `user` VALUES ('w', '123', NULL, NULL, NULL, NULL);
INSERT INTO `user` VALUES ('whuanle', '263727321', '女', '2020', NULL, NULL);
INSERT INTO `user` VALUES ('yang帆', '123', '男', '2019', NULL, NULL);
INSERT INTO `user` VALUES ('啊哈', '1234', NULL, NULL, NULL, NULL);
INSERT INTO `user` VALUES ('啊哈哈', '1', '男', '2019', 'wddqwdwdwd', '软件工程');

SET FOREIGN_KEY_CHECKS = 1;
