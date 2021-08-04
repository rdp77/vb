DROP TABLE IF EXISTS `terkini`;
CREATE TABLE `terkini` (
  `id` int(11) NOT NULL auto_increment,
  `isi` text,
  `tanggal` date default NULL,
  PRIMARY KEY  (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 AUTO_INCREMENT=42 ;