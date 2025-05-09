﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FrioAPI.Exception {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class ResourceErrorMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ResourceErrorMessages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("FrioAPI.Exception.ResourceErrorMessages", typeof(ResourceErrorMessages).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O CEP não foi encontrado..
        /// </summary>
        public static string CEP_NAO_ENCONTRADO {
            get {
                return ResourceManager.GetString("CEP_NAO_ENCONTRADO", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O campo (Cidade) é obrigatório..
        /// </summary>
        public static string CIDADE_OBRIGATORIO {
            get {
                return ResourceManager.GetString("CIDADE_OBRIGATORIO", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O campo (Data) é obrigatório..
        /// </summary>
        public static string DATA_OBRIGATORIA {
            get {
                return ResourceManager.GetString("DATA_OBRIGATORIA", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Não foi possível gerar um recibo anterior ao ano atual..
        /// </summary>
        public static string DATA_RECIBO_ANOATUAL {
            get {
                return ResourceManager.GetString("DATA_RECIBO_ANOATUAL", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O campo (Descricao Serviço) é obrigatório..
        /// </summary>
        public static string DESCRICAO_SERVICO_OBRIGATORIO {
            get {
                return ResourceManager.GetString("DESCRICAO_SERVICO_OBRIGATORIO", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O campo (Equipamento) é obrigatório..
        /// </summary>
        public static string EQUIPAMENTO_OBRIGATORIO {
            get {
                return ResourceManager.GetString("EQUIPAMENTO_OBRIGATORIO", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Erro desconhecido.
        /// </summary>
        public static string ERRO_DESCONHECIDO {
            get {
                return ResourceManager.GetString("ERRO_DESCONHECIDO", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O campo (Nome do cliente) é obrigatório..
        /// </summary>
        public static string NOME_CLIENTE_OBRIGATORIO {
            get {
                return ResourceManager.GetString("NOME_CLIENTE_OBRIGATORIO", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Recibo náo encontrado..
        /// </summary>
        public static string RECIBO_NAO_ENCONTRADO {
            get {
                return ResourceManager.GetString("RECIBO_NAO_ENCONTRADO", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O valor deve ser maior que zero.
        /// </summary>
        public static string TOTAL_MAIOR_QUE_ZERO {
            get {
                return ResourceManager.GetString("TOTAL_MAIOR_QUE_ZERO", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O campo (UF) é obrigatório..
        /// </summary>
        public static string UF_OBRIGATORIO {
            get {
                return ResourceManager.GetString("UF_OBRIGATORIO", resourceCulture);
            }
        }
    }
}
