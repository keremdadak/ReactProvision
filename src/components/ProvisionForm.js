import React, { Component } from 'react'
import Snackbar from '@material-ui/core/Snackbar';
import IconButton from '@material-ui/core/IconButton';
import { Button, Form } from 'react-bootstrap';
import Multipledll from './MultipleOperation';
import Select from 'react-select';

export class ProvisionForm extends Component {
    constructor(props) {
        super(props);
        this.state = {
            exp: [],
            diag: [],
            oprt: [],
            value: [],
            snacbaropen:false,
            snackbarmsg:''
        }
        this.handleSubmit = this.handleSubmit.bind(this);
    }
    snackbarClose=()=>{
        this.setState({
            snackbaropen:false
        });
    }

    componentDidMount() {
        fetch('http://localhost:5000/api/provision/expertise').then(response => response.json())
            .then(data => {
                this.setState({
                    exp: data
                });
            })
        fetch('http://localhost:5000/api/provision/diagnosis').then(respon => respon.json())
            .then(dt => {
                this.setState({
                    diag: dt
                });
            })
        fetch('http://localhost:5000/api/provision/complaint').then(rspn => rspn.json())
            .then(data2 => {
                this.setState({
                    oprt: data2
                });
            })
    }
    handleSubmit(e) {
        e.preventDefault();

        fetch('http://localhost:5000/api/provision/post', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                ProvisionID: 1,
                TCKN: e.target.TCKN.value,
                ProvisionDate: e.target.ProvisionDate.value,
                Expertise: e.target.Expertise.value,
                Diagnosis: e.target.Diagnosis.value,
                Complaint: e.target.Complaint.value,
                Operation: e.target.Operation.value
            })
        })
            .then(res => res.json())
            .then((result) => 
            {this.setState({
                snackbaropen:true,
                snackbarmsg:result
            });
        },
        (error)=>
        {
            this.setState({
                snackbaropen:true,
                snackbarmsg:error
            });
        }
            );

    }
    

    render() {
       
        const optionss = this.state.oprt.map(op =>
            ({ value: op.OperationID, label: op.OperationName }));
        return (
            <div className="container">
             <Snackbar
                anchorOrigin={{vertical:'center',horizontal:'center'}}
                open={this.state.snackbaropen}
                autoHideDuration={20000}
                onClose={this.snackbarClose}
                message={<span id="message-id">{JSON.stringify(this.state.snackbarmsg)}</span>}
                action={[
                    <IconButton key="close" aria-label="Close" color="inherit" onClick={this.snackbarClose}>
                        X
                        </IconButton>
                ]}
                />
                <h3>Ayakta Tedavi Provizyon Girişi</h3>

                <Form  onSubmit={this.handleSubmit}>
                    <Form.Group controlId="TCKN">
                        <Form.Label>Kimlik No</Form.Label>
                        <Form.Control
                            type="text"
                            name="TCKN"
                            required
                            placeholder="TC kimlik numarasını giriniz"
                        />
                    </Form.Group>
                    <Form.Group controlId="ProvisionDate">
                        <Form.Label>Provizyon Tarihi</Form.Label>
                        <Form.Control
                            type="date"
                            name="ProvisionDate"
                            required
                        />
                    </Form.Group>
                    <Form.Group controlId="Expertise">
                        <Form.Label>Uzmanlık</Form.Label>
                        <Form.Control as="select">
                            {this.state.exp.map(ex =>
                                <option key={ex.ExpertiseID}>
                                    {ex.ExpertiseName}
                                </option>
                            )}

                        </Form.Control>
                    </Form.Group>
                    <Form.Group controlId="Diagnosis">
                        <Form.Control as="select">
                            {this.state.diag.map(dg =>
                                <option key={dg.DiagnosisID}>
                                    {dg.DiagnosisName}
                                </option>
                            )}

                        </Form.Control>
                    </Form.Group>
                    <Form.Group controlId="Complaint">
                        <Form.Label>Şikayet</Form.Label>
                        <Form.Control as="textarea" rows={5}></Form.Control>
                    </Form.Group>

                    <Form.Group  controlId="Operation">
                        <Form.Control as="select"  > 
                            {this.state.oprt.map(opt =>
                                <option key={opt.OperationID}>
                                    {opt.OperationName}
                                </option>
                            )}</Form.Control>
                    </Form.Group>

                    {/* <Form.Group controlId="Operation">
                        <Multipledll oprt={this.state.oprt}/>
                        <Select isMulti options={optionss} onChange={this.handleChange}
                            closeMenuOnSelect={false}
                            placeholder="İşlem ara.."></Select>
                        {this.state.value === null ? "" : this.state.value.map(v => <h4 key={v.value}>{v.label}</h4>)}

                    </Form.Group> */}

                    <Button variant="secondary">Yeni Provizyon Al</Button>


                    <Button className="ml-2" variant="warning" type="submit">Provizyonu
                    Al</Button>



                </Form>

            </div>
        )
    }
}
