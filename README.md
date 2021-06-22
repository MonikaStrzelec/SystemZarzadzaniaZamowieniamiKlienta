
# Ramenik: system zarządzania zamówieniami
System do zamawiania jedzenia przez Internet z restauracji oferującej japońskie jedzenie z głównym uwzględnieniem ramenu. Restauracja będzie działać na terenie miasta Łodzi. System pozwoli klientowi na przejrzenie menu oraz zamówienie wymarzonego przez siebie dania. Jednocześnie podczas zamawiania klient będzie miał możliwość podglądu do zsumowanej ceny swojego zamówienia wraz z kosztami dostawy. Będzie też mógł przejrzeć zawartość koszyka oraz edytować ją. 

Aplikacja jest skierowana do klientów w różnym przedziale wiekowym, którzy chcą zjeść jedzenie zakupione w restauracji. Głównymi klientami restauracji Ramenik są osoby, które nie mają czasu na ugotowanie samodzielnie posiłku bądź też chcące urozmaicić swoją dietę. 

## Wymagania systemowe
* Microsoft SQL Server Managment Studio- projekt współpracuje z bazą danych
* Visual Studio 2019

## UWAGA
W pliku APP.config należy podac niezbędne dane do połaczenia się ze swoja baza danych.

w plikach wykożystywane są:
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

## Instalacja
Zaleca się pobranie programu za pomocą GitHube w dowolnym, pustym folderze.
