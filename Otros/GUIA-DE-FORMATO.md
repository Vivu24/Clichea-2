### Guia de formato de código
# Info
Esta guía define el formato de código a cumplir en todo el proyecto.
Está escrito en MarkDown por si en algún momento utilizamos otra plataforma para wiki.

**NO USAR**:
- tíldes 
- la ñ
- símbolos no ASCCI

# General
- Todas las definiciones deben ser en inglés

# Variables y métodos
- Todas las variables y métodos se escriben en camel case excepto si se especifica lo contrario.
(ej. myVariableWithCamelCase)

- Las variables privadas comienzan por _
(ej. _myPrivateVariable)

- Las variables públicas no comienzan con _
(ej. myPublicVariable)

- Los métodos empiezan por mayúscula. (excepto setters, getters y otros métodos estándar).
(ej. MyMethod())

- Las variables estáticas se escriben en mayúscula con espaciado _
(ej. MY_STATIC_VARIABLE)

- Las constantes Se escribe en mayusculas y con la barra baja como separador entre palabras
(ej. MY_STATIC_VARIABLE)
# Espaciado y tabulado

# Comentarios
- Los comentarios se escribirán en español y siempre que sea adecuado se utilizarán las herramientas de documentación propias de C# y Unity.
- Usar Summary en los métodos

# Editor Unity
- Usar Tooltip para los serializables

## Uso del código

- Las clases tendrán primero sus variables y referencias, despues se escribirán los métodos
- Uso de Regions