
--------------------------------------------王健 2023/11/02 START-------------------------------------------------

---飞书应用证书

CREATE TABLE `tbl_feishu_app_info` (
	`id` VARCHAR(50) NOT NULL,
	`code` VARCHAR(100) NOT NULL,
	`app_id` VARCHAR(100) NOT NULL DEFAULT '',
	`app_secret` VARCHAR(100) NOT NULL DEFAULT '',
	`app_token` VARCHAR(100) NOT NULL DEFAULT '',
	`table_id` VARCHAR(100) NOT NULL DEFAULT '',
	`access_token` VARCHAR(100) NULL DEFAULT NULL,
	`expire_date` DATETIME NULL DEFAULT NULL,
	`belong_live_anchor_id` INT(10) NOT NULL,
	`remark` VARCHAR(100) NULL DEFAULT NULL,
	`create_date` DATETIME NOT NULL,
	`update_date` DATETIME NULL DEFAULT NULL,
	`valid` BIT(1) NOT NULL,
	`delete_date` DATETIME NULL DEFAULT NULL,
	PRIMARY KEY (`id`)
);


---抖音短视频数据

CREATE TABLE `tbl_tiktok_short_video_data` (
	`id` VARCHAR(50) NOT NULL,
	`play_num` INT(10) NULL DEFAULT '0',
	`title` VARCHAR(200) NULL DEFAULT NULL,
	`like` INT(10) NULL DEFAULT '0',
	`video_id` VARCHAR(200) NULL DEFAULT NULL,
	`comments` INT(10) NULL DEFAULT '0',
	`belong_live_anchor_id` INT(10) NOT NULL DEFAULT '0',
	`create_date` DATETIME NOT NULL,
	`update_date` DATETIME NULL DEFAULT NULL,
	`valid` BIT(1) NOT NULL,
	`delete_date` DATETIME NULL DEFAULT NULL,
	PRIMARY KEY (`id`) 
);


--------------------------------------------王健 2023/11/02 END-------------------------------------------------

------------------------------------------王健  2024/1/18 BEGIN------------------------------------------

--飞书表格信息
CREATE TABLE `tbl_feishu_table` (
	`id` VARCHAR(50) NOT NULL,
	`app_token` VARCHAR(100) NOT NULL,
	`table_id` VARCHAR(100) NOT NULL DEFAULT '',
	`belong_app_id` VARCHAR(100) NOT NULL DEFAULT '',
	`table_type` INT NOT NULL,
	`live_anchorId` INT NOT NULL,
	`create_date` DATETIME NOT NULL,
	`update_date` DATETIME NULL DEFAULT NULL,
	`valid` BIT NOT NULL,
	`delete_date` DATETIME NULL DEFAULT NULL
);


--短视频评论数据
CREATE TABLE `tbl_short_video_comments` (
	`id` VARCHAR(50) NOT NULL,
	`comments_id` VARCHAR(500) NULL DEFAULT NULL,
	`comments_user_id` VARCHAR(500) NULL DEFAULT NULL,
	`comments_user_name` VARCHAR(500) NULL DEFAULT NULL,
	`like_count` INT NOT NULL DEFAULT 0,
	`comments` VARCHAR(1000) NULL DEFAULT NULL,
	`comments_date` DATETIME NULL DEFAULT NULL,
	`belong_live_anchor_id` INT NOT NULL DEFAULT 0,
	`create_date` DATETIME NOT NULL,
	`update_date` DATETIME NULL DEFAULT NULL,
	`valid` BIT NOT NULL DEFAULT 0,
	`delete_date` DATETIME NULL DEFAULT NULL,
	PRIMARY KEY (`id`)
);


---短视频粉丝数据
CREATE TABLE `tbl_short_video_fans_data` (
	`id` VARCHAR(50) NOT NULL,
	`stats_date` DATETIME NOT NULL,
	`new_fans_count` INT NOT NULL DEFAULT 0,
	`total_fans_count` INT NOT NULL DEFAULT 0,
	`belong_live_anchor_id` INT NULL DEFAULT 0,
	`create_date` DATETIME NOT NULL,
	`update_date` DATETIME NULL DEFAULT NULL,
	`valid` BIT NOT NULL DEFAULT 0,
	`delete_date` DATETIME NULL DEFAULT NULL
);
------------------------------------------王健  2024/1/18 END------------------------------------------

--------------------------------------------------------------------------------------------------------------------------------以上已发布至线上

