using Switchboard;
using Switchboard.Mapping;
using Switchboard.Profiles;
using Switchboard.Transformation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SwitchboardCLI
{
    public class SwitchboardClient : Client
    {
        private DataType inputType { get; set; }
        private DataType outputType { get; set; }

        public SwitchboardClient()
        {

        }

        public void Process(string dataReference, DataType inputType, DataType outputType, Map map)
        {

            this.inputType = inputType;
            this.outputType = outputType;


            ProcessObject(map);

            //example command  
        }

        protected override IEnumerable<IInput> GetData()
        {
           
            throw new NotImplementedException();
        }

        protected override bool SendData(IIntermediateObject obj)
        {
            switch (outputType)
            {
                case DataType.Object:
                    return HandleCreateObject();
                case DataType.JSON:
                    return HandleCreateJSON();
                case DataType.CSV:
                    return HandleCreateCSV();
                default:
                    return false;
            }
        }

        protected IEnumerable<IInput> HandleGetObject()
        {
            throw new NotImplementedException();

        }

        protected IEnumerable<IInput> HandedGetJSON()
        {
            throw new NotImplementedException();

        }

        protected IEnumerable<IInput> HandleGetCSV()
        {
            throw new NotImplementedException();

        }


        protected bool HandleCreateObject()
        {
            throw new NotImplementedException();

        }

        protected bool HandleCreateJSON()
        {
            throw new NotImplementedException();
        }

        protected bool HandleCreateCSV()
        {
            throw new NotImplementedException();

        }
    }
}
