import { useState } from 'react'
import styles from './Login.module.css'
import { LoginAsync } from '../../utils/requestXML/RequestLogin'
import swal from 'sweetalert'

export const Login = () => {
  const [form, setForm] = useState({
    email: '',
    password: '',
  });

  const handleChange = (e) => {
    const { name, value } = e.target
    setForm((prev) => {
      return {...prev, [name]: value}
    })
  }

  const handleSubmit = async(e) => {
    e.preventDefault()
    const request = await LoginAsync( form )
    console.log(request)
    if(request.Code === 401){
        swal({
            title: "Are you sure?",
            text: "Once deleted, you will not be able to recover this imaginary file!",
            icon: "warning",
            dangerMode: true,
          }).then(() => {
            window.location.reload()
            });
          return
    } else {
        window.location.href = "http://localhost:5173/Employees"
    }
  }

  return (
    <div className={styles.mainContainer}>
        <div className={styles.card}>
            <div className={styles.title}><h1>Iniciar sesión</h1></div>
            <form className={styles.form} onSubmit={handleSubmit}>
                <div className={styles.field}>
                    <label htmlFor="email">Nombre</label>
                    <input type="email" name="email" value={form.name} onChange={handleChange}/>
                </div>
                <div className={styles.field}>
                    <label htmlFor="password">Contraseña</label>
                    <input type="password" name="password" value={form.name} onChange={handleChange}/>
                </div>
                <input type="submit" value="Entrar"/>
            </form>
        </div>
    </div>
  )
}
