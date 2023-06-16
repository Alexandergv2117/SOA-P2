import { useEffect, useState } from "react"
import styles from "./AssetsEmployees.module.css"
import { GetAllDataActivoEmployee, UpdateActivoEmployee } from "../../../utils/requestXML/RequestAssetsEmployees"
import { OwnModal } from "../../common/OwnModal/OwnModal"
import { Add } from "../Add/Add"

export const AssetsEmployees = () => {
  const [assetsEmployees, setAssetsEmployees] = useState([])
  const [openAdd, setOpenAdd] = useState(false)

  const GetAssetsEmpolyees = async () => {
    try {
      const response = await GetAllDataActivoEmployee()
      setAssetsEmployees(response)
    } catch (error) {
      console.error(error)
    }
  }

  const deliverAsset = async(entity) => {
    try {
      const data = {
        id_empleoyee: entity.id_empleoyee,
        id_activo: entity.id_activo,
      }
      ////////////////////////////////
      await UpdateActivoEmployee( data )
      window.location.reload()
    } catch (error) {
      console.error(error)
    }
  }

  const handleAdd = () => {
    setOpenAdd(true)
  }

  const handleEdit = (e, entity) => {
    e.preventDefault()
    deliverAsset(entity)
  }

  useEffect(() => {
    GetAssetsEmpolyees()
  }, [])
  
  return (
    <div className={styles.mainContainer}>
      <div className={styles.title}>
        <h1>Activos Empleados</h1>
      </div>
      <div className={styles.table}>
        <div className={styles.tHeader}>
          <p>Empleado</p>
          <p>Activo</p>
          <p>assignment_date</p>
          <p>release_date</p>
          <p>activo</p>
          <p>Acciones</p>
        </div>
        <div className={styles.tBody}>
          { assetsEmployees.length >= 0 ?
            assetsEmployees.map((entity, index) => (
              <div key={index} className={styles.row}>
                <p>{entity.nameEmployee}</p>
                <p>{entity.nameActivo}</p>
                <p>{entity.assignment_date}</p>
                <p>{entity.release_date}</p>
                <p>{entity.status === false ? 'Disponible': 'Asignado'}</p>
                <div className={styles.btnEdit}>
                  <input type="button" onClick={(e) =>handleEdit(e, entity)} value="Entregar" />
                  {/* <button >Editar</button> */}
                </div>
              </div>
            )): null
          }
        </div>
      </div>
      <div className={styles.btnAdd}>
        <button onClick={handleAdd}>Agregar</button>
      </div>
      <OwnModal setOpen={setOpenAdd} open={openAdd}>
        <Add />
      </OwnModal>
    </div>
  )
}
