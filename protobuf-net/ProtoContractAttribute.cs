﻿using System;

namespace ProtoBuf
{
    /// <summary>
    /// Indicates that a type is defined for protocol-buffer serialization.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Enum,
        AllowMultiple = false, Inherited = true)]
    public sealed class ProtoContractAttribute : Attribute
    {
        /// <summary>
        /// Gets or sets the defined name of the type.
        /// </summary>
        public string Name { get { return name; } set { name = value; } }
        private string name;

        /// <summary>
        /// Gets or sets the fist offset to use with implicit field tags;
        /// only uesd if ImplicitFields is set.
        /// </summary>
        public int ImplicitFirstTag
        {
            get { return implicitFirstTag; }
            set
            {
                if (value < 1) throw new ArgumentOutOfRangeException("ImplicitFirstTag");
                implicitFirstTag = value; }
        }
        private int implicitFirstTag;

        /// <summary>
        /// Gets or sets the mechanism used to automatically infer field tags
        /// for members. This option should be used in advanced scenarios only.
        /// Please review the important notes against the ImplicitFields enumeration.
        /// </summary>
        public ImplicitFields ImplicitFields { get { return implicitFields; } set { implicitFields = value; } }
        private ImplicitFields implicitFields;

        #if NET_3_0

        private bool? inferTagFromName;
        /// <summary>
        /// Enables/disables automatic tag generation based on the existing name / order
        /// of the defined members. This option is not used for members marked
        /// with ProtoMemberAttribute, as intended to provide compatibility with
        /// WCF serialization. WARNING: when adding new fields you must take
        /// care to increase the Order for new elements, otherwise data corruption
        /// may occur.
        /// </summary>
        /// <remarks>If not specified, the default is assumed from <see cref="Serializer.GlobalOptions.InferTagFromName"/>.</remarks>
        public bool InferTagFromName
        {
            get { return inferTagFromName ?? Serializer.GlobalOptions.InferTagFromName; }
            set { inferTagFromName = value; }
        }

        #endif
    }
}