
using System;
using System.Collections.Generic;
using System.Text;

namespace GuidGenerate
{
       [GUID("d3906f66-8d72-42d5-abf8-1831d896d85a")]
	public class PersonBase 
	{
            [GUID("47f97ea2-f97e-4944-9e93-7700e498236c")]
    		private String name;
            [GUID("57008b2c-c546-4d5b-99df-67fe9f25563a")]
    		private String address;
            [GUID("d8cb297a-ecd2-40d8-a35a-3de0dee7ac77")]
    		private Int32 age;
            [GUID("dab77361-05d0-4cb8-b9cb-2ababd244885")]
    		private Boolean gender;
            [GUID("9ad996b6-6530-44de-afe5-9e10d5bf99d1")]
    		private List<String> list;

		public PersonBase(){}
    
		public String getName() {
        		return name;
        }

		public String getAddress() {
        		return address;
        }

		public Int32 getAge() {
        		return age;
        }

		public Boolean getGender() {
        		return gender;
        }

		public List<String> getList() {
        		return list;
        }


    		public void setName(String newValue) {
        		name = newValue;
        }

    		public void setAddress(String newValue) {
        		address = newValue;
        }

    		public void setAge(Int32 newValue) {
        		age = newValue;
        }

    		public void setGender(Boolean newValue) {
        		gender = newValue;
        }

    		public void setList(List<String> newValue) {
        		list = newValue;
        }

	}
}