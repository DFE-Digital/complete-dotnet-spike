import { v4 } from "uuid"

class DataGenerator {
    generateTemporaryId():string {
        const values:string = 'abcdefghijklmnopqrstuvwxyz0123456789'
        let tempId:string = ''
        let temp:string = ''

        for (let i = 0; i < 25; i++) {
            temp = values.charAt(Math.round(values.length * Math.random()))
            tempId += temp
        }

        temp = ''

        return tempId;
    }

    generateAlphaNumeric(length: number):string {
        const values:string = 'abcdefghijklmnopqrstuvwxyz0123456789'
        let tempId:string = ''
        let temp:string = ''

        for (let i = 0; i < length; i++) {
            temp = values.charAt(i % values.length)
            tempId += temp
        }

        temp = ''

        return tempId;
    }

    generateAlpha(length: number):string {
        const values:string = 'abcdefghijklmnopqrstuvwxyz'
        let tempId:string = ''
        let temp:string = ''

        for (let i = 0; i < length; i++) {
            temp = values.charAt(i % values.length)
            tempId += temp
        }

        temp = ''

        return tempId;
    }

    generateSchoolName(): string {
        return "(" + v4().substring(0, 4) + ")Test School"
    }
}

const dataGenerator = new DataGenerator();

export default dataGenerator;