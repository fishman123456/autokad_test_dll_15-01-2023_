(defun C:Fishman_ADD_NETLOAD (/ x1 x2 x3)
					;загружаем DLL 
  (vl-load-com)
  ;(vl-cmdf "_netload" "C:/Users/Fishman.DB.CORP/YandexDisk/Работа АСКО/AUTOCAD_Плагины/02-07-2021_/Layer_Add/bin/Debug/Layer_Add.dll") 
 (vl-cmdf "_netload" "C:/Users/Fishman_1/Documents/GitHub/autokad_test_dll_15-01-2023_/bin/Debug/autokad_test_dll_15-01-2023.dll")
  ;- лиспом dll загружаем
  (alert "DLL Загружен")
)
;"C:\Users\Fishman_1\Documents\GitHub\autokad_test_dll_15-01-2023_\bin\Debug\autokad_test_dll_15-01-2023.dll"