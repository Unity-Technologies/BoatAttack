using UnityEngine;

namespace Cinemachine
{
    /// <summary>
    /// Property applied to LensSettings.  Used for custom drawing in the inspector.
    /// </summary>
    public sealed class LensSettingsPropertyAttribute : PropertyAttribute
    {
    }
    
    /// <summary>
    /// Property applied to CinemachineBlendDefinition.  Used for custom drawing in the inspector.
    /// </summary>
    public sealed class CinemachineBlendDefinitionPropertyAttribute : PropertyAttribute
    {
    }

    /// <summary>
    /// Invoke play-mode-save for a class.  This class's fields will be scanned
    /// upon exiting play mode, and its property values will be applied to the scene object.
    /// This is a stopgap measure that will become obsolete once Unity implements
    /// play-mode-save in a more general way.
    /// </summary>
    public sealed class SaveDuringPlayAttribute : System.Attribute
    {
    }

    /// <summary>
    /// Suppresses play-mode-save for a field.  Use it if the calsee has [SaveDuringPlay] 
    /// attribute but there are fields in the class that shouldn't be saved.
    /// </summary>
    public sealed class NoSaveDuringPlayAttribute : PropertyAttribute
    {
    }

    /// <summary>Property field is a Tag.</summary>
    public sealed class TagFieldAttribute : PropertyAttribute
    {
    }

    /// <summary>
    /// Atrtribute to control the automatic generation of documentation.
    /// </summary>
    [DocumentationSorting(0f, DocumentationSortingAttribute.Level.Undoc)]
    public sealed class DocumentationSortingAttribute : System.Attribute
    {
        /// <summary>Refinement level of the documentation</summary>
        public enum Level 
        { 
            /// <summary>Type is excluded from documentation</summary>
            Undoc, 
            /// <summary>Type is documented in the API reference</summary>
            API, 
            /// <summary>Type is documented in the highly-refined User Manual</summary>
            UserRef 
        };
        /// <summary>Where this type appears in the manual.  Smaller number sort earlier.</summary>
        public float SortOrder { get; private set; }
        /// <summary>Refinement level of the documentation.  The more refined, the more is excluded.</summary>
        public Level Category { get; private set; }

        /// <summary>Contructor with specific values</summary>
        public DocumentationSortingAttribute(float sortOrder, Level category)
        {
            SortOrder = sortOrder;
            Category = category;
        }
    }
}
