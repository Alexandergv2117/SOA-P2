import { useState } from 'react'
import { CreatePerson } from '../../../utils/requestXML/RequestEmployees'
import styles from './Add.module.css'

// eslint-disable-next-line react/prop-types
export const Add = () => {
  const [form, setForm] = useState({
      curp: '',
      name: '',
      last_name: '',
      birth_date: '',
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
    await CreatePerson( form )
    window.location.reload()
  }

  return (
    <div className={styles.mainContainer}>
      <form className={styles.form} onSubmit={handleSubmit}>
      <div className={styles.field}>
        <label htmlFor="name">Nombre</label>
        <input type="text" name="name" value={form.name} onChange={handleChange}/>
      </div>
        <div className={styles.field}>
          <label htmlFor="curp">CURP</label>
          <input type="text" name="curp" value={form.curp} onChange={handleChange}/>
        </div>
        <div className={styles.field}>
          <label htmlFor="last_name">Apellido</label>
          <input type="text" name="last_name" value={form.last_name} onChange={handleChange}/>
        </div>
        <div className={styles.field}>
          <label htmlFor="birth_date">Cumpleaños</label>
          <input type="text" name="birth_date" value={form.birth_date} onChange={handleChange}/>
        </div>
        <div className={styles.field}>
          <label htmlFor="email">Email</label>
          <input type="text" name="email" value={form.email} onChange={handleChange}/>
        </div>
        <div className={styles.field}>
          <label htmlFor="password">Contraseña</label>
          <input type="password" name="password" value={form.password} onChange={handleChange}/>
        </div>
        <input type="submit" value="Guardar"/>
      </form>
    </div>
  )
}
  
