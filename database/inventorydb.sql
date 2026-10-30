-- phpMyAdmin SQL Dump
-- version 5.2.3
-- https://www.phpmyadmin.net/
--
-- Máy chủ: 127.0.0.1
-- Thời gian đã tạo: Th10 30, 2026 lúc 04:03 AM
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
-- Cơ sở dữ liệu: `inventorydb`
--

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `chitietphieukho`
--

CREATE TABLE `chitietphieukho` (
  `MaPhieu` int(11) NOT NULL,
  `MaVatTu` varchar(20) NOT NULL,
  `SoLuong` decimal(18,2) NOT NULL CHECK (`SoLuong` > 0),
  `DonGia` decimal(18,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `nhacungcap`
--

CREATE TABLE `nhacungcap` (
  `MaNCC` int(11) NOT NULL,
  `TenNCC` varchar(150) NOT NULL,
  `DienThoai` varchar(15) DEFAULT NULL,
  `DiaChi` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `nhacungcap`
--

INSERT INTO `nhacungcap` (`MaNCC`, `TenNCC`, `DienThoai`, `DiaChi`) VALUES
(1, 'Công ty Thép Hòa Phát', '02439281234', 'Hà Nội'),
(2, 'Nhà phân phối Xi măng Hà Tiên', '02838294567', 'TP.HCM'),
(3, 'Đại lý Vật liệu Xây dựng An Phát', '02223851122', 'Bắc Ninh');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `phieukho`
--

CREATE TABLE `phieukho` (
  `MaPhieu` int(11) NOT NULL,
  `LoaiPhieu` varchar(10) NOT NULL,
  `NgayLap` datetime DEFAULT current_timestamp(),
  `MaNCC` int(11) DEFAULT NULL,
  `TongTien` decimal(18,2) DEFAULT 0.00
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `vattu`
--

CREATE TABLE `vattu` (
  `MaVatTu` varchar(20) NOT NULL,
  `TenVatTu` varchar(150) NOT NULL,
  `DVT` varchar(20) DEFAULT NULL,
  `SoLuongTon` decimal(18,2) DEFAULT 0.00 CHECK (`SoLuongTon` >= 0)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `vattu`
--

INSERT INTO `vattu` (`MaVatTu`, `TenVatTu`, `DVT`, `SoLuongTon`) VALUES
('VT01', 'Thép Phi 12', 'Tấn', 50.00),
('VT02', 'Xi măng PCB40', 'Bao', 200.00),
('VT03', 'Gạch Tuynel 6 lỗ', 'Viên', 5000.00),
('VT04', 'Cát vàng xây dựng', 'Khối', 15.00);

--
-- Chỉ mục cho các bảng đã đổ
--

--
-- Chỉ mục cho bảng `chitietphieukho`
--
ALTER TABLE `chitietphieukho`
  ADD PRIMARY KEY (`MaPhieu`,`MaVatTu`),
  ADD KEY `MaVatTu` (`MaVatTu`);

--
-- Chỉ mục cho bảng `nhacungcap`
--
ALTER TABLE `nhacungcap`
  ADD PRIMARY KEY (`MaNCC`),
  ADD UNIQUE KEY `DienThoai` (`DienThoai`);

--
-- Chỉ mục cho bảng `phieukho`
--
ALTER TABLE `phieukho`
  ADD PRIMARY KEY (`MaPhieu`),
  ADD KEY `MaNCC` (`MaNCC`);

--
-- Chỉ mục cho bảng `vattu`
--
ALTER TABLE `vattu`
  ADD PRIMARY KEY (`MaVatTu`);

--
-- AUTO_INCREMENT cho các bảng đã đổ
--

--
-- AUTO_INCREMENT cho bảng `nhacungcap`
--
ALTER TABLE `nhacungcap`
  MODIFY `MaNCC` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT cho bảng `phieukho`
--
ALTER TABLE `phieukho`
  MODIFY `MaPhieu` int(11) NOT NULL AUTO_INCREMENT;

--
-- Ràng buộc đối với các bảng kết xuất
--

--
-- Ràng buộc cho bảng `chitietphieukho`
--
ALTER TABLE `chitietphieukho`
  ADD CONSTRAINT `chitietphieukho_ibfk_1` FOREIGN KEY (`MaPhieu`) REFERENCES `phieukho` (`MaPhieu`) ON DELETE CASCADE,
  ADD CONSTRAINT `chitietphieukho_ibfk_2` FOREIGN KEY (`MaVatTu`) REFERENCES `vattu` (`MaVatTu`);

--
-- Ràng buộc cho bảng `phieukho`
--
ALTER TABLE `phieukho`
  ADD CONSTRAINT `phieukho_ibfk_1` FOREIGN KEY (`MaNCC`) REFERENCES `nhacungcap` (`MaNCC`) ON DELETE SET NULL;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
