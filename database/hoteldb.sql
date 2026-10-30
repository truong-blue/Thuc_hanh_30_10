-- phpMyAdmin SQL Dump
-- version 5.2.3
-- https://www.phpmyadmin.net/
--
-- Máy chủ: 127.0.0.1
-- Thời gian đã tạo: Th10 30, 2026 lúc 03:50 AM
-- Phiên bản máy phục vụ: 10.11.16-MariaDB
-- Phiên bản PHP: 8.5.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Cơ sở dữ liệu: `hoteldb`
--

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `dichvu`
--

CREATE TABLE `dichvu` (
  `MaDV` int(11) NOT NULL,
  `TenDV` varchar(100) NOT NULL,
  `DonGia` decimal(18,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `dichvu`
--

INSERT INTO `dichvu` (`MaDV`, `TenDV`, `DonGia`) VALUES
(1, 'Nước suối', 10000.00),
(2, 'Cà phê', 20000.00),
(3, 'Mì ly', 15000.00),
(4, 'Giặt ủi', 50000.00);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `khachhang`
--

CREATE TABLE `khachhang` (
  `MaKH` int(11) NOT NULL,
  `HoTen` varchar(100) NOT NULL,
  `CCCD` varchar(20) NOT NULL,
  `SoDienThoai` varchar(15) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `phieudatphong`
--

CREATE TABLE `phieudatphong` (
  `MaPhieu` int(11) NOT NULL,
  `SoPhong` varchar(10) DEFAULT NULL,
  `MaKH` int(11) DEFAULT NULL,
  `NgayNhanPhong` datetime DEFAULT current_timestamp(),
  `NgayTraPhong` datetime DEFAULT NULL,
  `TongTienThanhToan` decimal(18,2) DEFAULT 0.00,
  `TrangThai` tinyint(1) DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `phong`
--

CREATE TABLE `phong` (
  `SoPhong` varchar(10) NOT NULL,
  `LoaiPhong` varchar(50) NOT NULL,
  `GiaTheoGio` decimal(18,2) NOT NULL,
  `TrangThai` varchar(30) DEFAULT 'Trống'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `phong`
--

INSERT INTO `phong` (`SoPhong`, `LoaiPhong`, `GiaTheoGio`, `TrangThai`) VALUES
('P101', 'Đơn', 50000.00, 'Trống'),
('P102', 'Đơn', 50000.00, 'Trống'),
('P201', 'Đôi', 80000.00, 'Trống'),
('P202', 'Đôi', 80000.00, 'Trống'),
('P301', 'VIP', 150000.00, 'Trống');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `sudungdichvu`
--

CREATE TABLE `sudungdichvu` (
  `MaPhieu` int(11) NOT NULL,
  `MaDV` int(11) NOT NULL,
  `SoLuong` int(11) NOT NULL,
  `ThoiGian` datetime NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Chỉ mục cho các bảng đã đổ
--

--
-- Chỉ mục cho bảng `dichvu`
--
ALTER TABLE `dichvu`
  ADD PRIMARY KEY (`MaDV`);

--
-- Chỉ mục cho bảng `khachhang`
--
ALTER TABLE `khachhang`
  ADD PRIMARY KEY (`MaKH`),
  ADD UNIQUE KEY `CCCD` (`CCCD`);

--
-- Chỉ mục cho bảng `phieudatphong`
--
ALTER TABLE `phieudatphong`
  ADD PRIMARY KEY (`MaPhieu`),
  ADD KEY `SoPhong` (`SoPhong`),
  ADD KEY `MaKH` (`MaKH`);

--
-- Chỉ mục cho bảng `phong`
--
ALTER TABLE `phong`
  ADD PRIMARY KEY (`SoPhong`);

--
-- Chỉ mục cho bảng `sudungdichvu`
--
ALTER TABLE `sudungdichvu`
  ADD PRIMARY KEY (`MaPhieu`,`MaDV`,`ThoiGian`),
  ADD KEY `MaDV` (`MaDV`);

--
-- AUTO_INCREMENT cho các bảng đã đổ
--

--
-- AUTO_INCREMENT cho bảng `dichvu`
--
ALTER TABLE `dichvu`
  MODIFY `MaDV` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT cho bảng `khachhang`
--
ALTER TABLE `khachhang`
  MODIFY `MaKH` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT cho bảng `phieudatphong`
--
ALTER TABLE `phieudatphong`
  MODIFY `MaPhieu` int(11) NOT NULL AUTO_INCREMENT;

--
-- Ràng buộc đối với các bảng kết xuất
--

--
-- Ràng buộc cho bảng `phieudatphong`
--
ALTER TABLE `phieudatphong`
  ADD CONSTRAINT `phieudatphong_ibfk_1` FOREIGN KEY (`SoPhong`) REFERENCES `phong` (`SoPhong`),
  ADD CONSTRAINT `phieudatphong_ibfk_2` FOREIGN KEY (`MaKH`) REFERENCES `khachhang` (`MaKH`);

--
-- Ràng buộc cho bảng `sudungdichvu`
--
ALTER TABLE `sudungdichvu`
  ADD CONSTRAINT `sudungdichvu_ibfk_1` FOREIGN KEY (`MaPhieu`) REFERENCES `phieudatphong` (`MaPhieu`) ON DELETE CASCADE,
  ADD CONSTRAINT `sudungdichvu_ibfk_2` FOREIGN KEY (`MaDV`) REFERENCES `dichvu` (`MaDV`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
