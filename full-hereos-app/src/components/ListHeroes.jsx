import React from 'react';
import { Table, Button, Row, Col, Form } from 'react-bootstrap';
import './list.css';
import swal from "sweetalert2";
import ReactDOM from "react-dom";

const BaseURL = 'https://localhost:44376/api';
export class ListHeroes extends React.Component {
    constructor(props) {
        super(props);
        this.state = {};
        this.inputName = React.createRef();
        this.inputPower = React.createRef();
        this.inputCompany = React.createRef();
        this.inputIsAlive = React.createRef();

        this.state = ({
            modalType: '',
            heroes: [],
            row: {},
            errorView: false,

        })

    }

    componentDidMount() {
        this.loadTable();
    }

    loadTable = async () => {
        try {
            let response = await fetch(`${BaseURL}/Heroe/GetAll`, {
                method: 'GET',
                headers: {
                    'Content-Type': 'application/json'
                }
            });
            if (response.status === 200) {
                let data = await response.json();
                this.setState({ heroes: data.heroes });
            }
            else if (response.status === 400 || response.status === 404 || response.status === 500) {
                let errorMessage = await response.text();
                if (errorMessage) {
                    swal.fire(
                        "ERROR",
                        errorMessage,
                        "error"
                    ).then(e => {
                        this.setState({ errorView: true });
                    });
                } else {
                    swal.fire(
                        "ERROR",
                        "Ocurrió un error interno al cargar la tabla, intente de nuevo.",
                        "error"
                    ).then(e => {
                        this.setState({ errorView: true });
                    });
                }

            }

        } catch (e) {
            this.setState({ errorView: true });
        }

    }
    cancelModal = () => {
        this.setState({ modalType: '' });
        return;
    }
    add = () => {

        return (
            <div className='modal-heroe'>
                <div className="modal-dialog modal-lg modal-dialog-scrollable">
                    <div className="modal-content">
                        <div className="modal-header">
                            <h5 className='modal-title px-4'>AGREGAR HEROE</h5>
                        </div>
                        <div className='modal-body'>
                            <Row >
                                <Col md={12}>

                                    <Form>
                                        <Form.Group className='mb-2 px-4' as={Row}>
                                            <Col sm="2">
                                                <label className='align-middle'>Nombre</label>
                                            </Col>
                                            <Col sm="10">
                                                <input
                                                    className='form-control'
                                                    ref={this.inputName}
                                                />
                                            </Col>
                                        </Form.Group>
                                        <Form.Group className='mb-2 px-4' as={Row}>
                                            <Col sm="2">
                                                <label className='align-middle'>Compa&ntilde;ia</label>
                                            </Col>
                                            <Col sm="10">
                                                <input
                                                    className='form-control'
                                                    ref={this.inputCompany}
                                                />
                                            </Col>
                                        </Form.Group>
                                        <Form.Group className='mb-2 px-4' as={Row}>
                                            <Col sm="2">
                                                <label className='align-middle'>Poder</label>
                                            </Col>
                                            <Col sm="10">
                                                <input
                                                    className='form-control'
                                                    ref={this.inputPower}
                                                />
                                            </Col>
                                        </Form.Group>

                                        <Form.Group className='mb-2 px-4' as={Row}>
                                            <Col sm="2">
                                                <label className='align-middle'>Estado</label>
                                            </Col>
                                            <Col sm="3">
                                                <select
                                                    ref={this.inputIsAlive}
                                                    className='form-control' >
                                                    <option value="true">VIVO</option>
                                                    <option value="false">MUERTO</option>
                                                </select>
                                            </Col>
                                        </Form.Group>
                                    </Form>
                                </Col>
                            </Row>
                        </div>
                        <div className="modal-footer">
                            <Row>
                                <Col className='mb-1 mt-1' md="12">
                                    <Button variant="success" className='mr-1' type='button' onClick={this.handleAdd}>
                                        Guardar
                                    </Button >
                                    <Button variant="secondary" type='button' onClick={this.cancelModal} >
                                        Cancelar
                                    </Button>
                                </Col>
                            </Row>
                        </div>
                    </div>
                </div>
            </div>
        );



    };
    modify = (row) => {
        let heroeToEdit = {
            name: row.name,
            power: row.power,
            isAlive: row.isAlive,
            company: row.company,
            idHeroe: row.idHeroe
        };
        return (
            <div className='modal-heroe'>
                <div className="modal-dialog modal-lg modal-dialog-scrollable">
                    <div className="modal-content">
                        <div className="modal-header">
                            <h5 className='modal-title px-4'>MODIFICAR HEROE</h5>
                        </div>
                        <div className='modal-body'>
                            <Row >
                                <Col md={12}>

                                    <Form>
                                        <Form.Group className='mb-2 px-4' as={Row}>
                                            <Col sm="2">
                                                <label className='align-middle'>Nombre</label>
                                            </Col>
                                            <Col sm="10">
                                                <input
                                                    className='form-control'
                                                    defaultValue={heroeToEdit.name}
                                                    ref={this.inputName}
                                                />
                                            </Col>
                                        </Form.Group>
                                        <Form.Group className='mb-2 px-4' as={Row}>
                                            <Col sm="2">
                                                <label className='align-middle'>Compa&ntilde;ia</label>
                                            </Col>
                                            <Col sm="10">
                                                <input
                                                    className='form-control'
                                                    defaultValue={heroeToEdit.company}
                                                    ref={this.inputCompany}
                                                />
                                            </Col>
                                        </Form.Group>
                                        <Form.Group className='mb-2 px-4' as={Row}>
                                            <Col sm="2">
                                                <label className='align-middle'>Poder</label>
                                            </Col>
                                            <Col sm="10">
                                                <input
                                                    className='form-control'
                                                    defaultValue={heroeToEdit.power}
                                                    ref={this.inputPower}
                                                />
                                            </Col>
                                        </Form.Group>

                                        <Form.Group className='mb-2 px-4' as={Row}>
                                            <Col sm="2">
                                                <label className='align-middle'>Estado</label>
                                            </Col>
                                            <Col sm="3">
                                                <select
                                                    defaultValue={heroeToEdit.isAlive}
                                                    ref={this.inputIsAlive}
                                                    className='form-control' >
                                                    <option value="true">VIVO</option>
                                                    <option value="false">MUERTO</option>
                                                </select>
                                            </Col>
                                        </Form.Group>
                                    </Form>
                                </Col>
                            </Row>
                        </div>
                        <div className="modal-footer">
                            <Row>
                                <Col className='mb-1 mt-1' md="12">
                                    <Button variant="success" className='mr-1' type='button' onClick={this.handleModify}>
                                        Guardar
                                    </Button >
                                    <Button variant="secondary" type='button' onClick={this.cancelModal} >
                                        Cancelar
                                    </Button>
                                </Col>
                            </Row>
                        </div>
                    </div>
                </div>
            </div>
        );



    };
    delete = (row) => {
        let heroeToDelete = {
            name: row.name,
            power: row.power,
            isAlive: row.isAlive,
            company: row.company,
            idHeroe: row.idHeroe
        };
        return (
            <div className='modal-heroe'>
                <div className="modal-dialog modal-lg modal-dialog-scrollable">
                    <div className="modal-content">
                        <div className="modal-header">
                            <h5 className='modal-title px-4'>ELIMINAR HEROE</h5>
                        </div>
                        <div className='modal-body'>
                            <Row >
                                <Col md={12}>

                                    <h5 style={{ textAlign: 'center', fontWeight: 'bold' }}>
                                        &iquest;Est&aacute; seguro que desea eliminar el siguiente heroe?
                                    </h5>

                                    <Form>
                                        <Form.Group className='mb-2 px-4' as={Row}>
                                            <Col sm="2">
                                                <label className='align-middle'>Nombre</label>
                                            </Col>
                                            <Col sm="10">
                                                <input
                                                    disabled
                                                    className='form-control'
                                                    defaultValue={heroeToDelete.name}
                                                    ref={this.inputName}
                                                />
                                            </Col>
                                        </Form.Group>
                                        <Form.Group className='mb-2 px-4' as={Row}>
                                            <Col sm="2">
                                                <label className='align-middle'>Compa&ntilde;ia</label>
                                            </Col>
                                            <Col sm="10">
                                                <input
                                                    disabled
                                                    className='form-control'
                                                    defaultValue={heroeToDelete.company}
                                                    ref={this.inputCompany}
                                                />
                                            </Col>
                                        </Form.Group>
                                        <Form.Group className='mb-2 px-4' as={Row}>
                                            <Col sm="2">
                                                <label className='align-middle'>Poder</label>
                                            </Col>
                                            <Col sm="10">
                                                <input
                                                    disabled
                                                    className='form-control'
                                                    defaultValue={heroeToDelete.power}
                                                    ref={this.inputPower}
                                                />
                                            </Col>
                                        </Form.Group>

                                        <Form.Group className='mb-2 px-4' as={Row}>
                                            <Col sm="2">
                                                <label className='align-middle'>Estado</label>
                                            </Col>
                                            <Col sm="3">
                                                <select
                                                    disabled
                                                    defaultValue={heroeToDelete.isAlive}
                                                    ref={this.inputIsAlive}
                                                    className='form-control' >
                                                    <option value="true">VIVO</option>
                                                    <option value="false">MUERTO</option>
                                                </select>
                                            </Col>
                                        </Form.Group>
                                    </Form>
                                </Col>
                            </Row>
                        </div>
                        <div className="modal-footer">
                            <Row>
                                <Col className='mb-1 mt-1' md="12">
                                    <Button variant="danger" className='mr-1' type='button' onClick={this.handleDelete}>
                                        Eliminar
                                    </Button >
                                    <Button variant="secondary" type='button' onClick={this.cancelModal} >
                                        Cancelar
                                    </Button>
                                </Col>
                            </Row>
                        </div>
                    </div>
                </div>
            </div>
        );



    };

    handleAdd = async (e) => {
        e.preventDefault();
        let heroe = {};
        heroe.name = this.inputName.current.value;
        heroe.company = this.inputCompany.current.value;
        heroe.power = this.inputPower.current.value;
        if (this.inputIsAlive.current.value === 'true') {
            heroe.isAlive = true;
        } else if (this.inputIsAlive.current.value === 'false') {
            heroe.isAlive = false;
        }
        try {
            const response = await fetch(`${BaseURL}/Heroe/Add`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(heroe),
            });
            this.setState({ modalType: '' });
            if (response.status === 200) {
                swal.fire(
                    "ÉXITO",
                    "Heroe agregado con éxito.",
                    "success"
                ).then(() => {
                    this.loadTable();
                });
            } else if (response.status === 400 || response.status === 404 || response.status === 500) {
                let errorMessage = await response.text();
                if (errorMessage) {
                    swal.fire(
                        "ERROR",
                        errorMessage,
                        "error"
                    ).then(() => {
                        this.loadTable();
                    });
                } else {
                    swal.fire(
                        "ERROR",
                        "Ocurrió un error al agregar el heroe, intente de nuevo",
                        "error"
                    );
                }
            }
        } catch (error) {
            swal.fire(
                "ERROR",
                "Ocurrió un error interno, intente de nuevo.",
                "error"
            );

        }
    };
    handleModify = async (e) => {
        e.preventDefault();
        let { row } = this.state;
        row.name = this.inputName.current.value;
        row.company = this.inputCompany.current.value;
        row.power = this.inputPower.current.value;
        if (this.inputIsAlive.current.value === 'true') {
            row.isAlive = true;
        } else if (this.inputIsAlive.current.value === 'false') {
            row.isAlive = false;
        }
        try {
            const response = await fetch(`${BaseURL}/Heroe/Edit`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(row),
            });
            this.setState({ modalType: '' });
            if (response.status === 200) {
                swal.fire(
                    "ÉXITO",
                    "Heroe modificado con éxito.",
                    "success"
                ).then(() => {
                    this.loadTable();
                });
            } else if (response.status === 400 || response.status === 404 || response.status === 500) {
                let errorMessage = await response.text();
                if (errorMessage) {
                    swal.fire(
                        "ERROR",
                        errorMessage,
                        "error"
                    ).then(() => {
                        this.loadTable();
                    });
                } else {
                    swal.fire(
                        "ERROR",
                        "Ocurrió un error al modificar el heroe, intente de nuevo",
                        "error"
                    );
                }
            }
        } catch (error) {
            swal.fire(
                "ERROR",
                "Ocurrió un error interno, intente de nuevo.",
                "error"
            );

        }
    };

    handleDelete = async (e) => {
        e.preventDefault();
        let { row } = this.state;
        let deleteHeroeRequest = {};
        deleteHeroeRequest.idHeroe = row.idHeroe;
        try {
            const response = await fetch(`${BaseURL}/Heroe/Delete`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(deleteHeroeRequest),
            });
            this.setState({ modalType: '' });
            if (response.status === 200) {
                swal.fire(
                    "ÉXITO",
                    "Heroe eliminado con éxito.",
                    "success"
                ).then(() => {
                    this.loadTable();
                });
            } else if (response.status === 400 || response.status === 404 || response.status === 500) {
                let errorMessage = await response.text();
                if (errorMessage) {
                    swal.fire(
                        "ERROR",
                        errorMessage,
                        "error"
                    ).then(() => {
                        this.loadTable();
                    });
                } else {
                    swal.fire(
                        "ERROR",
                        "Ocurrió un error al eliminar el heroe, intente de nuevo",
                        "error"
                    );
                }
            }
        } catch (error) {
            swal.fire(
                "ERROR",
                "Ocurrió un error interno, intente de nuevo.",
                "error"
            );

        }
    };

    conditionalModalRender = () => {
        const { modalType } = this.state;
        const { row } = this.state;
        switch (modalType) {
            case "Modify": {
                return this.modify(row);
            }
            case "Delete": {
                return this.delete(row);
            }
            case "Add": {
                return this.add();
            }
            default:
                return <></>;
        }
    };
    renderTable = () => {
        return this.state.heroes.map((heroe, index) => {
            const { idHeroe, company, isAlive, name, power } = heroe;
            let isAliveString = '';
            if (isAlive === true) {
                isAliveString = 'Vivo';
            } else {
                isAliveString = 'Muerto';
            }
            return (
                <tr key={idHeroe}>
                    <td>{idHeroe}</td>
                    <td>{name}</td>
                    <td>{company}</td>
                    <td>{power}</td>
                    <td>{isAliveString}</td>
                    <td>
                        <Button className='mr-1' onClick={() => {
                            this.setState({ modalType: 'Modify' });
                            this.setState({ row: heroe });
                        }} variant="warning">Editar</Button>
                        <Button onClick={() => {
                            this.setState({ modalType: 'Delete' });
                            this.setState({ row: heroe });
                        }} variant="danger">Eliminar</Button>
                    </td>
                </tr>
            )
        })
    };

    render() {
        let { errorView } = this.state;

        if (errorView === true) {
            return (
                <h1>No se encuentran datos.</h1>
            );
        } else {
            return (
                <>
                    <Row>
                        <Col md={1}></Col>

                        <Col md={10}>
                            <h1 style={{ textAlign: 'left' }} >Lista de Heroes</h1>
                            <hr className='line' />
                        </Col>
                    </Row>
                    <Row>
                        <Col md={1}></Col>
                        <Col md={10}>
                            <Table striped bordered hover >
                                <thead>
                                    <tr>
                                        <th>Id</th>
                                        <th>Nombre</th>
                                        <th>Compa&ntilde;ia</th>
                                        <th>Poder</th>
                                        <th>Estado</th>
                                        <th>Acci&oacute;n</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    {this.renderTable()}
                                </tbody>
                            </Table>
                            <Button onClick={() => {
                                this.setState({ modalType: 'Add' });
                            }} variant="primary" > Nuevo</Button>
                        </Col>

                    </Row>
                    {
                        this.conditionalModalRender()
                    }
                </>
            );
        }

    }

}
