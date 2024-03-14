using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lection07_Reflection
{
    public class MySerializer
    {
        /// <summary>
        /// преобразование объекта в строку(сериализация)
        /// </summary>
        /// <param name="obj">преобразуемый объект</param>
        /// <returns></returns>
        public static string ObjectToString ( object obj )
        {
            //тип объекта и все его поля и свойства
            var type = obj.GetType( );
            var members = type.GetMembers( BindingFlags.Public | BindingFlags.Instance );
            
            var keyValuePairs = new List<string>( );

            foreach ( var member in members )
            {
                //поиск аттрибута
                var customNameAttr = member.GetCustomAttribute<CustomNameAttribute>( );
                //обработка поля/свойства помеченного атрибутом
                if ( customNameAttr != null )
                {
                    object? value;
                    switch ( member.MemberType )
                    {
                        case MemberTypes.Field:
                        {
                            FieldInfo? fieldInfo = member as FieldInfo;
                            value = fieldInfo?.GetValue( obj );
                            keyValuePairs.Add( $"{customNameAttr.Name}:{value}" );
                            break;
                        }
                        case MemberTypes.Property:
                        {
                            var propInfo = ( PropertyInfo )member;
                            if ( propInfo.CanRead )
                            {
                                value = propInfo.GetValue( obj );
                                keyValuePairs.Add( $"{customNameAttr.Name}:{value}" );
                            }
                            break;
                        }
                    }
                }
            }
            return string.Join( "," , keyValuePairs );
        }

        /// <summary>
        /// преобразование строки к обобщеному типу
        /// </summary>
        /// <typeparam name="T"> тип к которому происходит приведение(при этом T должен иметь конструктор по умолчанию)</typeparam>
        /// <param name="str">строка содержащая сериализованное свойство/поле</param>
        /// <returns></returns>
        public static T StringToObject<T> ( string str ) where T : new()
        {
            var obj = new T( );
            var type = typeof( T );
            var keyValuePairs = str.Split( ',' );
            foreach ( var pair in keyValuePairs )
            {
                var parts = pair.Split( ':' );
                if ( parts.Length == 2 )
                {
                    var propName = parts[ 0 ];
                    var valueStr = parts[ 1 ];

                    //массив полей и свойств в типе
                    var members = type.GetMembers( BindingFlags.Public | BindingFlags.Instance );

                    foreach ( var member in  members)
                    {
                        //аттрибут заданного типа
                        var attr = member.GetCustomAttribute<CustomNameAttribute>( );
                        if ( attr != null && attr.Name == propName )
                        {
                            //тип поля/свойства
                            var currentType = (( FieldInfo )member ).FieldType ;
                            //получаем из строки заданный тип
                            object value = Convert.ChangeType( valueStr , currentType );
                            //установка значения value в поле или свойство obj
                            if ( member.MemberType == MemberTypes.Field )
                            {//тип является полем
                                ( ( FieldInfo )member ).SetValue( obj , value );
                            } else if ( member.MemberType == MemberTypes.Property )
                            {//тип является свойством
                                ( ( PropertyInfo )member ).SetValue( obj , value );
                            }
                            break;
                        }
                    }
                }
            }

            return obj;
        }
    }
}
