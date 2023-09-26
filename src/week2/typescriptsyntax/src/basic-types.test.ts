import { describe, expect, it } from 'vitest';

describe('Types in TypeScript', () => {
    describe('Implicit Typing', () => {
        it('An Example', () => {
            let a = 10, b = 20, answer;

            answer = a + b;

            expect(answer).toBe(30);
        })

        it('Implicit Typing when you Initialize a Variable', () => {
            type AgeType = 'Minor' | 'Adult'; 
            let age: number | AgeType = 54;

            age = 'Adult';

            expect(age).toBe('Adult');

            let name: string;

            name = 'Pedro';

            expect('tacos').toEqual("tacos");

        });
    })

})