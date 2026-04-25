[README.md](https://github.com/user-attachments/files/27081948/README.md)
# ManteHospital (ManteHos)

Sistema de gestión de mantenimiento hospitalario desarrollado en C# con arquitectura en capas, Entity Framework 6 y Windows Forms.

---

## Descripción

ManteHospital es una aplicación de escritorio para la gestión de incidencias de mantenimiento en un entorno hospitalario. Permite a distintos roles de usuario (Jefe, Maestro, Operario, Empleado) interactuar con el sistema según sus responsabilidades: reportar incidencias, revisarlas, asignar órdenes de trabajo y cerrarlas.

---

## Arquitectura

El proyecto sigue una arquitectura en tres capas:

```
ManteHos/
├── ClassLibrary/                  # Biblioteca principal (lógica + persistencia)
│   ├── BusinessLogic/
│   │   ├── Entities/              # Clases de dominio (constructores y lógica)
│   │   └── Services/              # Interfaz IManteHosService + implementación
│   └── Persistence/
│       ├── Entities/              # Propiedades, anotaciones EF y relaciones
│       └── EntityFrameWorkImp/    # DbContext, DAL, IDAL
├── ManteHosGUI/                   # Capa de presentación (Windows Forms)
├── ManteHosPersistenceTests/      # Tests de persistencia (MSTest)
├── ManteHosObjectDesignTests/     # Tests de diseño de objetos (MSTest)
├── DBTest/                        # Consola para poblar y verificar la BD
└── 4-BusinessLogicTest/           # Consola para probar la capa de servicio
```

### Patrón de clases parciales

Cada entidad se divide en dos archivos `.cs`:

| Archivo | Responsabilidad |
|---|---|
| `BusinessLogic/Entities/` | Constructores, inicialización de colecciones, lógica de negocio |
| `Persistence/Entities/` | Propiedades con anotaciones `[Key]`, `[Required]`, relaciones `virtual` |

---

## Entidades del dominio

```
Employee (base)
├── Head          — Jefe: puede revisar incidencias
├── Master        — Maestro: gestiona un Área, asigna órdenes de trabajo
└── Operator      — Operario: ejecuta órdenes de trabajo (tiene Turno)

Area              — Zona del hospital, asociada a un Master
Incident          — Incidencia reportada por un Employee
WorkOrder         — Orden de trabajo vinculada a una Incident
Part              — Pieza de repuesto con stock
UsedPart          — Pieza usada en una WorkOrder (controla stock)
```

### Ciclo de vida de una incidencia

```
Created → Accepted / Rejected → InProgress → Completed
```

---

## Roles y funcionalidades

| Rol | Funcionalidades |
|---|---|
| **Empleado** | Reportar incidencias |
| **Jefe (Head)** | Revisar incidencias: aceptar (con área y prioridad) o rechazar (con motivo) |
| **Maestro (Master)** | Ver incidencias de su área, crear y asignar órdenes de trabajo a operarios |
| **Operario (Operator)** | Ver sus órdenes de trabajo abiertas, cerrar órdenes con informe y fecha |

---

## Tecnologías

- **Lenguaje:** C# (.NET Framework 4.7.2)
- **ORM:** Entity Framework 6.5.1 (Code First)
- **Base de datos:** SQL Server LocalDB (`(localdb)\MSSQLLocalDB`)
- **UI:** Windows Forms
- **Tests:** MSTest 2.2.10

---

## Requisitos previos

- Visual Studio 2017 o superior
- .NET Framework 4.7.2
- SQL Server LocalDB (incluido con Visual Studio)
- NuGet (para restaurar paquetes)

---

## Instalación y ejecución

1. **Clonar el repositorio:**
   ```bash
   git clone <url-del-repositorio>
   ```

2. **Abrir la solución:**
   Abre `ProyectoPracticas.sln` en Visual Studio.

3. **Restaurar paquetes NuGet:**
   En Visual Studio: clic derecho sobre la solución → *Restaurar paquetes NuGet*.

4. **Verificar cadenas de conexión:**
   Los archivos `App.config` de cada proyecto apuntan a:
   ```
   Server=(localdb)\mssqllocaldb;Database=ManteHosDB;Trusted_Connection=True
   ```
   La GUI usa una base de datos separada: `ManteHosDBFinal`.

5. **Establecer proyecto de inicio:**
   Clic derecho sobre `ManteHosGUI` → *Establecer como proyecto de inicio*.

6. **Ejecutar:**
   Presiona `F5`. La aplicación inicializa la base de datos automáticamente con datos de prueba en el primer arranque.

---

## Usuarios de prueba (cargados en `DBInitialization`)

| Id | Contraseña | Rol |
|---|---|---|
| `h1` | `h1` | Jefe (Head) |
| `m1` | `m1` | Maestro — Área Mecánica |
| `m2` | `m2` | Maestro — Área Electricidad |
| `m3` | `m3` | Maestro — Área Pintura |
| `o1` | `o1` | Operario — Turno Mañana |
| `o2` | `o2` | Operario — Turno Mañana |
| `o3` | `o3` | Operario — Turno Noche |
| `e1` | `e1` | Empleado |
| `e2` | `e2` | Empleado |

---

## Ejecución de tests

### Tests de diseño de objetos (`ManteHosObjectDesignTests`)

Verifican que las entidades tengan la estructura correcta: propiedades virtuales, constructores, inicialización de colecciones, herencia.

```
Test Explorer → ManteHosObjectDesignTests → Ejecutar todos
```

### Tests de persistencia (`ManteHosPersistenceTests`)

Verifican que cada entidad se almacena y recupera correctamente de la base de datos, incluyendo relaciones bidireccionales.

```
Test Explorer → ManteHosPersistenceTests → Ejecutar todos
```

> **Nota:** Los tests de persistencia requieren acceso a SQL Server LocalDB y limpian la base de datos antes y después de cada test.

---

## Proyectos de consola auxiliares

- **`DBTest`:** Crea un conjunto de datos de ejemplo en la BD y los imprime por consola. Útil para verificar el estado de la base de datos manualmente.
- **`4-BusinessLogicTest`:** Prueba el login/logout y otras operaciones del servicio desde consola.

---

## Estructura de la solución

```
Solución ProyectoPracticas
├── Presentation
│   └── ManteHosGUI
└── Library
│   └── ManteHosLib
└── Testing
    ├── ManteHosObjectDesignTests
    ├── ManteHosPersistenceTests
    ├── DBTest
    └── 4-BusinessLogicTest
```

---

## Notas de desarrollo

- Las entidades usan el patrón **partial class** para separar lógica de persistencia sin modificar archivos generados.
- El `DbContext` tiene `LazyLoadingEnabled = true` y `ProxyCreationEnabled = true` para cargar relaciones automáticamente.
- El método `RemoveAllData()` en `DbContextISW` elimina todos los registros de todas las entidades usando reflexión, útil para los tests.
- La regla de negocio de `AssignWorkOrder` exige que todos los operarios asignados pertenezcan al mismo turno.
