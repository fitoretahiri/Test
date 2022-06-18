import { useState } from "react";
import { Link, Redirect } from "react-router-dom";

const RestorantiRegister = () => {
    const [username, setUsername] = useState('');
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [redirect, setRedirect] = useState(false); 

    const submit = async (event) => {
        event.preventDefault();
        
        await fetch(process.env.REACT_APP_API+'authmanagement/register',{
            method:'POST',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            body:JSON.stringify({
                username,
                email,
                password,
                roli: 'Restorant'
            })
        }).then(res=>res.json())
        .then((result)=>{
            console.log(result);
            if(!result.success){
                alert(result.errors[0]);
            }else{
                alert('jeni regjistruar me sukses');
                setRedirect(true);
            }
        },
        (error)=>{
            alert('Failed');
        })
        
    }

    if(redirect){
        return <Redirect to="/"/>
    }

    return (
        <div className="d-flex justify-content-center align-content-center">

            <form className="row g-3 d-flex w-50 mt-4 mb-3" onSubmit={submit}>
                <nav className="navbar bg-light">
                    <button className="btn btn-sm btn-outline-secondary" type="button"><Link to="/klientiregister" >Klient</Link></button>
                    <button className="btn btn-sm btn-outline-secondary" type="button"><Link to="/restorantiregister" >Restorant</Link></button>
                    <button className="btn btn-sm btn-outline-secondary" type="button"><Link to="/transportuesiregister" >Transportues</Link></button>
                </nav>
                <h1>Regjistrohu Si Restorant!</h1>
                <div className="col-sm-12 align-self">
                    <label for="inputEmail4" className="form-label">Email</label>
                    <input type="email" className="form-control" id="inputEmail4" onChange={e => setEmail(e.target.value)} />
                </div>
                <div className="col-sm-12">
                    <label for="inputPassword4" className="form-label">Password</label>
                    <input type="password" className="form-control" id="inputPassword4" onChange={e => setPassword(e.target.value)} />
                </div>
                <div className="col-sm-12">
                    <label for="emri" className="form-label">Emri</label>
                    <input type="text" className="form-control" id="emri" onChange={e => setUsername(e.target.value)} />
                </div>
                <div className="col-sm-12">
                    <label for="inputState" className="form-label">Qyteti</label>
                    <select id="inputState" className="form-select">
                        <option selected>Choose...</option>
                        <option>...</option>
                    </select>
                </div>
                <div className="col-sm-12">
                    <label for="adresa" className="form-label">Adresa</label>
                    <input type="text" className="form-control" id="adresa" />
                </div>
                <div className="col-sm-12">
                    <label for="nr_telefonit" className="form-label">Nr. Telefonit</label>
                    <input type="text" className="form-control" id="nr_telefonit" />
                </div>
                <div className="col-sm-12">
                    <label for="foto" className="form-label">Foto Profilit</label>
                    <input type="file" className="form-control" id="fotos" />
                </div>

                <div className="col-12">
                    <button type="submit" className="btn btn-primary">Regjistrohu</button>
                </div>
            </form>
        </div>
    );
}

export default RestorantiRegister;