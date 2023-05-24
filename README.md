# Resúmen
API para obtener datos diversos de Recursos Humanos desde una Base de Datos "Oracle".
Actualmente se pueden obtener datos de los empleados, sus historiales de trabajo y los departamentos donde se desempeñan.

# Endpoints
## [GET] /Department
Permite obtener los distintos departmentos de la empresa y los empleados que trabajan en ellos.
![image](https://github.com/mmilladsys/RRHHApi/assets/134303570/1a597d25-26c3-4af3-8b13-4d60dca8ee4b)
## [POST] /Department
Permite insertar un departamento nuevo de la empresa en la tabla.<br>
![image](https://github.com/mmilladsys/RRHHApi/assets/134303570/70db983c-f7b7-4097-9211-3a08d4f5e634)<br>
![image](https://github.com/mmilladsys/RRHHApi/assets/134303570/51619b71-df44-483c-ad29-9192eca96d84)
## [GET] /Employee
Permite obtener la información de todos los empleados que trabajan en la empresa.
![image](https://github.com/mmilladsys/RRHHApi/assets/134303570/9c2fb4ba-17f0-426f-81ca-cdd2380d4475)
## [GET] /Programmers
Permite obtener la información de todos los empleados "programadores" de la empresa.<br>
![image](https://github.com/mmilladsys/RRHHApi/assets/134303570/7989219e-4cff-4f8c-8a4e-852ff3addbd6)<br>
Comprobación: <br>
![image](https://github.com/mmilladsys/RRHHApi/assets/134303570/3055fb1c-2588-4453-9c91-94099fceb306)
## [GET] /History
Permite obtener el historial de trabajo de cada empleado durante su estadía en la empresa.
![image](https://github.com/mmilladsys/RRHHApi/assets/134303570/acd12af6-fc0e-461e-bb71-dff4d1f7903d)<br>
![image](https://github.com/mmilladsys/RRHHApi/assets/134303570/e88daac0-0d19-4990-8120-13c4412c42ad)
## [GET] /JobHistory
Permite obtener nombre e email del primer trabajador (historicamente) registrado en el historial de trabajo de la empresa.
![image](https://github.com/mmilladsys/RRHHApi/assets/134303570/786e4718-3e05-487a-9cac-92706131cafe)<br>
Comprobación: <br>
![image](https://github.com/mmilladsys/RRHHApi/assets/134303570/6f2ac3b5-dc48-4e30-8660-eaa5b6249782)

