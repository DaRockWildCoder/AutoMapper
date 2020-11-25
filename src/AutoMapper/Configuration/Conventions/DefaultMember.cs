using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace AutoMapper.Configuration.Conventions
{
    // Source Destination Mapper
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class DefaultMember : IChildMemberConfiguration
    {
        public IParentSourceToDestinationNameMapper NameMapper { get; set; }

        public bool MapDestinationPropertyToSource(ProfileMap options, TypeDetails sourceTypeDetails, Type destType, Type destMemberType, string nameToSearch, List<MemberInfo> resolvers, IMemberConfiguration parent = null, bool isReverseMap = false)
        {
            if (string.IsNullOrEmpty(nameToSearch))
            {
                return true;
            }
            var matchingMemberInfo = NameMapper.GetMatchingMemberInfo(sourceTypeDetails, destType, destMemberType, nameToSearch);
            if (matchingMemberInfo != null)
            {
                resolvers.Add(matchingMemberInfo);
                return true;
            }
            return false;
        }
    }
}