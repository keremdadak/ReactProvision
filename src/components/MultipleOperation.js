import React, { Component } from 'react';
import Select from 'react-select';

//Çoklu işlem seçimi için yapıldı ancak provisionform.js de farklı şekilde kullandım gerek kalmadı şuanlık.
class Multipledll extends Component{
    constructor(props){
        super(props);
        this.state={
            value:[]
        }
    }
    handleChange(e){
        this.setState({value:e})
        
    }
    render(){
        console.log(this.state.value);
    const optionss=this.props.oprt.map(op=>
        ({value:op.OperationID, label:op.OperationName})); 
    return(
        <div>
            {console.log(this.state.op)}
            <Select isMulti options={optionss} onChange={this.handleChange.bind(this)}
            closeMenuOnSelect={false}
            placeholder="İşlem ara.."></Select>
           { this.state.value === null ? "" : this.state.value.map(v=> <h4 key={v.value}>{v.label}</h4>)}
            
           
        </div>
    );
}
}
export default Multipledll;
