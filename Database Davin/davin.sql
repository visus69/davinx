-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jan 21, 2023 at 11:42 PM
-- Server version: 10.4.27-MariaDB
-- PHP Version: 8.2.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `davin`
--

-- --------------------------------------------------------

--
-- Table structure for table `datainventaris`
--

CREATE TABLE `datainventaris` (
  `id` int(11) NOT NULL,
  `nama_barang` varchar(100) NOT NULL,
  `kategori` varchar(100) NOT NULL,
  `tanggal_masuk` date NOT NULL,
  `tanggal_keluar` date NOT NULL,
  `jumlah_barang` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `datainventaris`
--

INSERT INTO `datainventaris` (`id`, `nama_barang`, `kategori`, `tanggal_masuk`, `tanggal_keluar`, `jumlah_barang`) VALUES
(14, 'Jati', 'Kayu', '2022-12-01', '2023-01-02', 100),
(15, 'Pinus', 'Kayu', '2023-01-03', '2023-01-09', 50),
(16, 'Baja', 'Besi', '2023-01-01', '2023-01-08', 30),
(17, 'Alloy', 'Alumunium', '2022-12-30', '2023-02-02', 50),
(18, 'Meja', 'Acrylic', '2022-10-04', '2022-01-09', 20),
(19, 'Jemuran', 'Besi', '2023-01-10', '2023-01-10', 1),
(20, 'Kursi', 'Kayu', '2023-01-10', '2023-01-10', 11),
(21, 'Kursi', 'Alumunium', '2023-01-10', '2023-01-19', 10),
(22, 'Meja', 'Besi', '2023-01-10', '2023-01-10', 3),
(23, 'Balok', 'Alumunium', '2023-01-10', '2023-01-10', 69),
(24, 'Kanvas', 'Acrylic', '2023-01-10', '2023-01-10', 1),
(25, 'Lonceng', 'Besi', '2022-12-26', '2023-02-04', 1),
(28, 'Gelas', 'Acrylic', '2023-01-12', '2023-01-19', 10);

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE `user` (
  `id` int(11) NOT NULL,
  `username` varchar(100) NOT NULL,
  `password` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `user`
--

INSERT INTO `user` (`id`, `username`, `password`) VALUES
(1, 'akhdanferdiansyah46@gmail.com', 'akhdansaja123'),
(2, 'a', 'a');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `datainventaris`
--
ALTER TABLE `datainventaris`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `datainventaris`
--
ALTER TABLE `datainventaris`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=31;

--
-- AUTO_INCREMENT for table `user`
--
ALTER TABLE `user`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
